[CmdletBinding()]
param (
    [string]
    [Parameter(Mandatory = $true)]
    $MSBuild = $null,

    [string]
    [Parameter(Mandatory = $true)]
    $RepositoryRoot,

    [string[]]
    $Target = $null,

    [ValidatePattern('^(\d+\.\d+\.\d+)?$')]
    $Version = '',

    [switch]
    $Release,

    [string]
    [ValidateSet('Debug', 'Release')]
    $Configuration = 'Release',

    [ValidateSet('quiet', 'normal', 'detailed')]
    $Verbosity = 'normal'
)

# Set initial directories for the build.
$buildDir = Join-Path $RepositoryRoot 'build'
$nuget = Join-Path $buildDir 'nuget.exe'
$nuspecDir = Join-Path $RepositoryRoot 'nuget'
$sourceDir = Join-Path $RepositoryRoot 'src'
$outputDir = Join-Path $RepositoryRoot '_out'

# If no version number was specified, load it from the 'version.json' file.
if ([string]::IsNullOrEmpty($Version)) {
    $versionJson = Get-Content (Join-Path $RepositoryRoot 'version.json') -Raw | ConvertFrom-Json
    $Version = "$($versionJson.major).$($versionJson.minor).$($versionJson.patch)"
}

# Set the version number strings.
$versionSuffix = if ($Release) { '' } else { '-dev-' + [DateTime]::Now.ToString('yyMMddHHmmss') }
$versionNumber = "$Version.0"
$versionString = $Version + $versionSuffix

# Write out the version number being built.
Write-Host -NoNewline "Building version "
Write-Host -NoNewline -ForegroundColor Green $versionNumber
Write-Host -NoNewline ' / '
Write-Host -ForegroundColor Green $versionString

# Make sure there's a build target set.
if ($Target -eq $null -or $Target.Length -eq 0) { $Target = 'CompileAndPackage' }



########## Build Tasks ##########

task . $Target

task CompileAndPackage Compile, Package

task RestorePackages {
    Get-ChildItem (Join-Path $SourceDir *.sln) |
        ForEach {
            $packageDir = Join-Path $_.DirectoryName 'packages'
            Exec {
                & $nuget restore $_ -PackagesDirectory $packageDir
            }
        }
}

task UpdateVersionFiles {
    Get-ChildItem (Join-Path $sourceDir '**\AssemblyInfo.cs') |
        ForEach {
            $assemblyInfo = Get-Content $_
            $assemblyInfo |
                ForEach {
                    $line = $_
                    $line = $line -replace '(AssemblyVersion\s*\(\s*)".*"(\s*\))', "`$1`"$versionNumber`"`$2"
                    $line = $line -replace '(AssemblyFileVersion\s*\(\s*)".*"(\s*\))', "`$1`"$versionNumber`"`$2"
                    $line = $line -replace '(AssemblyInformationalVersion\s*\(\s*)".*"(\s*\))', "`$1`"$versionString`"`$2"
                    $line
                } |
                Set-Content $_ -Encoding UTF8
        }
}

task Compile RestorePackages, UpdateVersionFiles, {
    Get-ChildItem (Join-Path $SourceDir *.sln) |
        ForEach {
            Exec {
                & $MSBuild $_ /m /v:$Verbosity /property:"Configuration=$Configuration"
            }
        }
}

task Package {
    Get-ChildItem (Join-Path $nuspecDir *.nuspec) |
        ForEach {
            Write-Host -NoNewline "Creating NuGet package from "
            Write-Host -ForegroundColor Green $_.Name
            Exec {
                Write-Verbose "$nuget pack $_ -BasePath $sourceDir -OutputDirectory $outputDir -Version `"$versionString`" -Properties `"Configuration=$Configuration`" -Verbosity $Verbosity"
                & $nuget pack $_ -BasePath $sourceDir -OutputDirectory $outputDir -Version "$versionString" -Properties "Configuration=$Configuration" -Verbosity $Verbosity
            }
        }
}

task Clean {
    Get-ChildItem (Join-Path $sourceDir *.sln) |
        ForEach {
            Write-Host -ForegroundColor Red "Cleaning `"$($_.Name)`""
            Exec {
                & $MSBuild $_ /m /v:$Verbosity /property:"Configuration=$Configuration" /target:Clean
            }

            Write-Host -ForegroundColor Red "Removing packages for `"$($_.Name)`""
            $packageDir = Join-Path $_.DirectoryName 'packages'
            if (Test-Path -PathType Container $packageDir) {
                Remove-Item -Recurse $packageDir -ErrorAction Continue
            }
        }

    Write-Host -ForegroundColor Red "Removing build packages"
    $packageDir = Join-Path $buildDir 'packages'
    if (Test-Path -PathType Container $packageDir) {
        Remove-Item -Recurse $packageDir -ErrorAction Continue
    }

    Write-Host -ForegroundColor Red "Removing build output"
    if (Test-Path -PathType Container $outputDir) {
        Remove-Item -Recurse $outputDir -ErrorAction Continue
    }
}
