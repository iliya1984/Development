using BoltTest.Core.ErrorHandling;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace BoltTest.API.Results
{
    public class ExceptionResult : IActionResult
    {
        private List<Exception> _exceptions;

        public ExceptionResult(Exception exception)
        {
            _exceptions = new List<Exception> { exception };
        }

        public ExceptionResult(List<Exception> exceptions)
        {
            _exceptions = exceptions;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var errors = _exceptions.Select(e => toError(e)).ToList();

            var objectContent = new ObjectContent<List<Error>>(errors, new JsonMediaTypeFormatter());

            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = objectContent,
                StatusCode = HttpStatusCode.InternalServerError
            };
            return Task.FromResult(response);
        }

        private Error toError(Exception e)
        {
            var response = new Error
            {
                Message = e.Message,
                StackTrace = e.StackTrace
            };

            return response;
        }
    }
}
