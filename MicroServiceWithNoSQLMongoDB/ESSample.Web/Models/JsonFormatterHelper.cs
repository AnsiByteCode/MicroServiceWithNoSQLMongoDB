//-----------------------------------------------------------------------
// <copyright file="JsonFormatterHelper.cs" company="AnsiBytecode">
// Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace ABC.Common.Helper
{
    using System;
    using System.Net.Http.Formatting;

    /// <summary>
    /// JSON Formatter Helper
    /// </summary>
    public sealed class JsonFormatterHelper
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static volatile JsonFormatterHelper instance;

        /// <summary>
        /// The JSON formatter
        /// </summary>
        private static MediaTypeFormatter jsonFormatter;

        /// <summary>
        /// The synchronize root
        /// </summary>
        private static object syncRoot = new object();

        /// <summary>
        /// Prevents a default instance of the <see cref="JsonFormatterHelper"/> class from being created.
        /// </summary>
        private JsonFormatterHelper()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static JsonFormatterHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new JsonFormatterHelper();
                            if (jsonFormatter == null)
                            {
                                jsonFormatter = new JsonMediaTypeFormatter();
                            }
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets the JSON media type formatter.
        /// </summary>
        /// <value>
        /// The JSON media type formatter instance.
        /// </value>
        public MediaTypeFormatter JsonMediaTypeFormatterInstance
        {
            get
            {
                return jsonFormatter;
            }

            private set
            {
            }
        }
    }
}
