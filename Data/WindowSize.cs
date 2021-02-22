//
// FILE     : WindowSize.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-19
// 

namespace AruaRoseLoginManager.Data
{
    /// <summary>
    /// Holds window size information for the login manager window (defaults + current)
    /// </summary>
    public class WindowSize
    {
        /// <summary>
        /// Default size width
        /// </summary>
        private const int DEFAULT_WIDTH = 650;

        /// <summary>
        /// Default size height
        /// </summary>
        private const int DEFAULT_HEIGHT = 650;

        /// <summary>
        /// Compact size width
        /// </summary>
        private const int COMPACT_WIDTH = 270;

        /// <summary>
        /// Compact size height
        /// </summary>
        private const int COMPACT_HEIGHT = 650;

        /// <summary>
        /// Gets the default window size
        /// </summary>
        public static WindowSize Default {
            get
            {
                return new WindowSize() { Height = DEFAULT_HEIGHT, Width = DEFAULT_WIDTH };
            }
        }

        /// <summary>
        /// Gets the compact window size
        /// </summary>
        public static WindowSize Compact
        {
            get
            {
                return new WindowSize() { Height = COMPACT_HEIGHT, Width = COMPACT_WIDTH };
            }
        }

        /// <summary>
        /// Window width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Window height
        /// </summary>
        public int Height { get; set; }
    }
}
