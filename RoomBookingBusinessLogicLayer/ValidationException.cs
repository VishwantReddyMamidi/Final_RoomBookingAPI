using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class ValidationExcep : Exception
    {
        public int Code { get; set; }
        public ValidationExcep(int code, string message) : base(message)
        {
            Code = code;
        }
    }
}