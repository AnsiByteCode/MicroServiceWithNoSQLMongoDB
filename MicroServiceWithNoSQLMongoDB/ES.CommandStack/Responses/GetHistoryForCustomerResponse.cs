namespace ES.CommandStack.Responses
{
    #region Using
    using ES.Common;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Get History For Customer Response
    /// </summary>
    public class GetHistoryForCustomerResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the history items.
        /// </summary>
        /// <value>
        /// The history items.
        /// </value>
        public IEnumerable<HistoryItem> HistoryItems { get; set; }
    }
}
