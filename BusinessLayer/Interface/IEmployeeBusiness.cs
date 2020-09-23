using BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBusiness<T> : IBusiness<T>
    {
        Result<Employee> SelectbyEmail(string email);
    }
}
