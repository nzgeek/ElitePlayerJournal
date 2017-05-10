using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Converters;

namespace NZgeek.ElitePlayerJournal.Events.Types
{
    /// <summary>
    ///     The position of a system in the galaxy.
    /// </summary>
    [JsonConverter(typeof(SystemPositionConverter))]
    public class SystemPosition
    {
        internal SystemPosition(decimal x, decimal y, decimal z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        ///     The X coordinate of the system.
        /// </summary>
        public decimal X { get; }

        /// <summary>
        ///     The Y coordinate of the system.
        /// </summary>
        public decimal Y { get; }

        /// <summary>
        ///     The Z coordinate of the system.
        /// </summary>
        public decimal Z { get; }

        /// <summary>
        ///     A display value for this object.
        /// </summary>
        public override string ToString() => $"[{X}, {Y}, {Z}]";
    }
}
