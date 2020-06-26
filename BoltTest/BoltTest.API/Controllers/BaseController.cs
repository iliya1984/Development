using BoltTest.API.Results;
using BoltTest.Core.ErrorHandling;
using BoltTest.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoltTest.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ExceptionResult Exception(Exception ex) 
        {
            return new ExceptionResult(ex);
        }

        protected ErrorResult Error(IErrorResponse response) 
        {
            return new ErrorResult(response.Errors);
        }
    }
}
