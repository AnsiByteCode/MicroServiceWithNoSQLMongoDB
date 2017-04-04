namespace ES.EventStore
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Stream Name Extensions
    /// </summary>
    public static class StreamNameExtensions
    {
        private static char _separator = '@';

        /// <summary>
        /// Identifiers the specified stream name.
        /// </summary>
        /// <param name="streamName">Name of the stream.</param>
        /// <returns></returns>
        public static Guid Id(this string streamName)
        {
            var strings = streamName.Split(_separator);
            return new Guid(strings[1]);
        }

        /// <summary>
        /// Types the specified stream name.
        /// </summary>
        /// <param name="streamName">Name of the stream.</param>
        /// <returns></returns>
        public static string Type(this string streamName)
        {
            var strings = streamName.Split(_separator);
            return strings[0];
        }
    }
}
