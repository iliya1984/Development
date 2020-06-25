using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.Core.ErrorHandling
{
    public class Error
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
