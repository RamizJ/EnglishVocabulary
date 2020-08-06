using System;
using System.Net;

namespace Vocabulary.Backend.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpResponseException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HttpResponseException()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="value"></param>
        public HttpResponseException(HttpStatusCode statusCode, object value)
        {
            StatusCode = statusCode;
            Value = value;
        }
    }
}
