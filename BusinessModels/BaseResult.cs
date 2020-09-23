using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels
{
    public class BaseResult
    {
        public bool IsSuccess { get; set; }
        public string ReasonForFailure { get; set; }
        public string SuccessMessage { get; set; }
    }
}
