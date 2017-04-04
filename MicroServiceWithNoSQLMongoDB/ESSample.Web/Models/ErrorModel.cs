using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ESSample.Web.Models
{
    public class ErrorModel
    {
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the ex.
        /// </summary>
        /// <value>
        /// The ex.
        /// </value>
        public Exception Exception { get; set; }
    }
}