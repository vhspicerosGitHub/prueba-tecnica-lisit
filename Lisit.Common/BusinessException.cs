using System.Net;

namespace Lisit.Common
{
    public class BusinessException : Exception
    {
        public HttpStatusCode HttpStatusCode { set; get; }

        public BusinessException(string message) : base(message)
        {
            HttpStatusCode = HttpStatusCode.BadRequest;
        }
        public BusinessException(string message, HttpStatusCode statusCode) : base(message)
        {
            HttpStatusCode = statusCode;
        }

        public BusinessException(string message, Exception inner, HttpStatusCode statusCode) : base(message, inner)
        {
            HttpStatusCode = statusCode;
        }
    }
}