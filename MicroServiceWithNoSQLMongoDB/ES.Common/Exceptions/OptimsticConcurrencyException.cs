namespace ES.Common.Exceptions
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Optimstic Concurrency Exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class OptimsticConcurrencyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptimsticConcurrencyException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public OptimsticConcurrencyException(string message) : base(message) { }
    }
}
