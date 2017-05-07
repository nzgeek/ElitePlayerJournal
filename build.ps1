[CmdletBinding()]
param (
    [Parameter(Position = 0)]
    [string[]]
    $Target = $null,

    [ValidatePattern('^(\d+\.\d+\.\d+)?$')]
    $Version = '',

    [switch]
    $Release,

    [string]
    [ValidateSet('Debug', 'Release')]
    $Configuration = 'Release',

    [string]
    [ValidatePattern('^(\d+\.\d+|\*)$')]
    $MSBuildVersion = '*',
    
    [ValidateSet('quiet', 'normal', 'detailed')]
    $Verbosity = 'normal'
)
process
{
    $buildDir = Join-Path $PSScriptRoot 'build'
    $buildPackages = Join-Path $buildDir 'packages'

    # Restore any tools needed during the build process
    & (Join-Path $buildDir nuget.exe) restore (Join-Path $buildDir packages.config) -PackagesDirectory $buildPackages

    # Locate the Invoke-Build script file
    $invokeBuild = Get-ChildItem (Join-Path $buildPackages 'Invoke-Build.*\tools') | Resolve-Path
    Write-Verbose "Using 'Invoke-Build' from `"$invokeBuild`""

    # Get the location of MSBuild.exe
    $msbuild = & (Join-Path $invokeBuild 'Resolve-MSBuild.ps1') $MSBuildVersion
    Write-Verbose "Using 'msbuild.exe' at `"$msbuild`""

    # Run the build script
    Get-ChildItem (Join-Path $buildDir '*.build.ps1') |
        ForEach {
            $buildParameters = @{
                MSBuild = $msbuild
                RepositoryRoot = $PSScriptRoot
                Target = $Target
                Version = $Version
                Release = $Release
                Configuration = $Configuration
                Verbosity = $Verbosity
            }

            Write-Host -NoNewline 'Building '
            Write-Host -ForegroundColor Green $_
            & (Join-Path $invokeBuild 'Invoke-Build.ps1') -Task $Targets -File $_ @buildParameters
        }
}