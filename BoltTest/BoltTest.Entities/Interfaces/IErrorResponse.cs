using BoltTest.Core.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.Entities.Interfaces
{
    public interface IErrorResponse
    {
        IEnumerable<Error> Errors { get; }
        bool HasErrors { get; }
        void AddError(Error error);
        void AddErrors(IEnumerable<Error> errors);
    }
}
