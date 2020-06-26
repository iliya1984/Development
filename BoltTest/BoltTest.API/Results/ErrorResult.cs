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
    public class ErrorResult : IActionResult
    {
        private List<Error> _errors;

        public ErrorResult(Error error)
        {
            _errors = new List<Error> { error };
        }

        public ErrorResult(IEnumerable<Error> errors)
        {
            _errors = errors.ToList();
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var objectContent = new ObjectContent<List<Error>>(_errors, new JsonMediaTypeFormatter());

            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = objectContent,
                StatusCode = HttpStatusCode.InternalServerError
            };
            return Task.FromResult(response);
        }
    }
}
