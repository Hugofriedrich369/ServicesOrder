using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OSDSII.api.Http;
using System.Net;

namespace OSDSII.api.Exceptions
{
    public class BaseException : Exception
    {
        private HttpErrorResponse HttpResponse { get; set; }
        private HttpStatusCode StatusCode { get; set; }
        public BaseException(string errorCode,
            string message,
            HttpStatusCode httpStatusCode,
            int statusCode,
            DateTimeOffset timestamp,
            Exception? ex)
        {
            StatusCode = httpStatusCode;
            HttpResponse = new HttpErrorResponse(errorCode, message, statusCode, timestamp);
        }
        public IActionResult GetResponse()
        {
            return new ContentResult
            {
                StatusCode = ((int)StatusCode),
                Content = JsonConvert.SerializeObject(HttpResponse, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
                )
            };
        }
    }
}
