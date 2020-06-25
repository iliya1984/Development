using BoltTest.Core.ErrorHandling;
using BoltTest.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoltTest.Entities.Responses
{
    public abstract class BaseResponse: IErrorResponse
    {
        private List<Error> _errors;

        public IEnumerable<Error> Errors { get { return _errors; } }

        public BaseResponse()
        {
            _errors = new List<Error>();
        }

        public BaseResponse(IEnumerable<Error> errors) 
        {
            _errors = errors.ToList();
        }

        public void AddError(Error error)
        {
            if (error == null) 
            {
                throw new ArgumentNullException();
            }

            _errors.Add(error);
        }

        public void AddErrors(IEnumerable<Error> errors)
        {
            if (errors == null)
            {
                throw new ArgumentNullException();
            }

            _errors.AddRange(errors);
        }
    }
}
