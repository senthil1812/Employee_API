using BusinessModels;
using DataLayer.DBContext;
using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataLayer.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Result<Employee> SelectbyEmail(Expression<Func<Employee, bool>> predicate)
        {
            var result = _repositoryContext.Set<Employee>().Where(predicate).ToList().FirstOrDefault();
            var resultModel = new Result<Employee>
            {
                Data = result,
                IsSuccess = true,
                SuccessMessage = "Record Details!!"

            };

            return resultModel;
        }
    }
}
