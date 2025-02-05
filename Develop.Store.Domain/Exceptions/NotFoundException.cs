using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace Develop.Store.Domain.Exceptions
{
    [Serializable]
    public class NotFoundException : DefaultException
    {
        public override LogLevel Level { get { return LogLevel.Error; } }

        public override HttpStatusCode StatusCode { get { return HttpStatusCode.NotFound; } }


        public NotFoundException(string? message) : base(message)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
