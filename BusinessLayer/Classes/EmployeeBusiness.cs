using BusinessLayer.Interface;
using BusinessModels;
using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Class
{
    public class EmployeeBusiness : BaseBusiness<Employee>,IEmployeeBusiness<Employee>
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeBusiness(IEmployeeRepository userRepository) : base(userRepository)
        {
            _repository = userRepository;
        }

        public Result<Employee> SelectbyEmail(string email)
        {
            return _repository.SelectbyEmail(x => x.Email == email);
        }
    }
}
