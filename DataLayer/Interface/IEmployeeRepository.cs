using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataLayer.Interface
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Result<Employee> SelectbyEmail(Expression<Func<Employee, bool>> predicate);
    }
}
