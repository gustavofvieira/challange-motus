using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace Develop.Store.Domain.Exceptions
{
    [Serializable]
    public class DefaultException : Exception
    {
        public virtual LogLevel Level { get {  return LogLevel.Error; } }

        public virtual HttpStatusCode StatusCode {  get { return HttpStatusCode.InternalServerError; } }

        public DefaultException(string message) : base(message) { }

        //public DefaultException(Exception innerException) { }
        public DefaultException(SerializationInfo info, StreamingContext context) : base (info, context) { }

    }
}
