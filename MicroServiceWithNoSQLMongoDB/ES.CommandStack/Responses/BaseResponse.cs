namespace ES.CommandStack.Responses
{
    /// <summary>
    /// Base Response
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseResponse"/> class.
        /// </summary>
        public BaseResponse()
        {
            Success = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BaseResponse"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
    }
}
