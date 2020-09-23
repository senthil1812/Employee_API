using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels
{
    public class Result<T> : BaseResult
    {       
        public T Data { get; set; }
    }
}
