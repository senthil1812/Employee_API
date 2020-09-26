using BusinessLayer.Class;
using BusinessLayer.Interface;
using BusinessModels;
using DataLayer.DBContext;
using DataLayer.Interface;
using DataLayer.Repository;
using EmployeeDetails.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private readonly IEmployeeBusiness<Employee> employeeBuiness;
        private IConfigurationRoot _configuration;
        public EmployeeControllerTest()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json");
            _configuration = builder.Build();
            var services = new ServiceCollection();
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(_configuration["ConnectionStrings:DataBaseConnection"]));
            services.AddScoped<IEmployeeBusiness<Employee>, EmployeeBusiness>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            var serviceProvider = services.BuildServiceProvider();

            employeeBuiness = serviceProvider.GetService<IEmployeeBusiness<Employee>>();
        }


        #region Case for Add Employee
        [TestMethod]
        public async  Task AddEmployee()
        {
            try
            {
                //Arrange
                var empRequest = new Employee() {
                                                FirstName = "gowtham",
                                                LastName = "k",
                                                DOB =  Convert.ToDateTime("1992-09-24T15:26:25.733"),
                                                Gender = "male",
                                                Email = "ram@gmail.com",
                                                Phone= "8566415236",
                                                Department = "IT"
                                              };
                var controller = new EmployeeController(employeeBuiness);

                // Act
                var actionResult = await  controller.PostAsync(empRequest);
                var json = JsonConvert.SerializeObject(actionResult);
                var jobject = JObject.Parse(json);
                var employee = jobject["Value"]["Value"].ToObject<Employee>();
                // Assert
                Assert.IsNotNull(employee);
                Assert.AreEqual(empRequest.Email, employee.Email);
                Assert.AreEqual(empRequest.FirstName, employee.FirstName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Case for Update Employee
        [TestMethod]
        public void UpdateEmployee()
        {
            try
            {
                //Arrange
                var empRequest = new Employee()
                {
                    Id = 4,
                    FirstName = "gowtham",
                    LastName = "l",
                    DOB = Convert.ToDateTime("1992-09-24T15:26:25.733"),
                    Gender = "male",
                    Email = "gowtham@gmail.com",
                    Phone = "8566415236",
                    Department = "IT"
                };
                var controller = new EmployeeController(employeeBuiness);

                // Act
                var actionResult = controller.Put(empRequest);
                var json = JsonConvert.SerializeObject(actionResult);
                var jobject = JObject.Parse(json);
                var employee = jobject["Value"]["Value"].ToObject<Employee>();
                // Assert
                Assert.IsNotNull(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Case for Delete Employee
        [TestMethod]
        public void DeleteEmployee()
        {
            try
            {
                //Arrange
                var empId = 5;
                var message = "Employee Deleted Successfully!";
               var controller = new EmployeeController(employeeBuiness);

                // Act
                var actionResult = controller.Delete(empId);
                var json = JsonConvert.SerializeObject(actionResult);
                var jobject = JObject.Parse(json);
                var responseMsg = jobject["Value"]["Value"];
                // Assert
                Assert.AreEqual(message, responseMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Case for Get all Employee
        [TestMethod]
        public void GetAllEmployee()
        {
            try
            {
                //Arrange
                var empName = "senthil";
                var controller = new EmployeeController(employeeBuiness);

                // Act
                var actionResult = controller.Get();
                var json = JsonConvert.SerializeObject(actionResult);
                var jobject = JObject.Parse(json);
                var data = JsonConvert.SerializeObject(jobject["Value"]["Value"]["Data"]);
                var empList = JsonConvert.DeserializeObject<List<Employee>>(data);
                // Assert
                Assert.IsNotNull(empList);
                Assert.AreEqual(empName, empList[0].FirstName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Case for Get Employee by id
        [TestMethod]
        public void EmployeeGetById()
        {
            try
            {
                var empId = 1;
                //Arrange
                var controller = new EmployeeController(employeeBuiness);

                // Act
                var actionResult = controller.Get(empId);
                var json = JsonConvert.SerializeObject(actionResult);
                var jobject = JObject.Parse(json);
                var employee = jobject["Value"]["Value"].ToObject<Employee>();

                // Assert
                Assert.IsNotNull(employee);
                Assert.AreEqual(empId, employee.Id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Case for Get  Employee by Email
        [TestMethod]
        public void EmployeeGetByEmail()
        {
            try
            {
                var empEmail = "senthil@gmail.com";
                //Arrange
                var controller = new EmployeeController(employeeBuiness);

                // Act
                var actionResult = controller.SelectbyEmail(empEmail);
                var json = JsonConvert.SerializeObject(actionResult);
                var jobject = JObject.Parse(json);
                var employee = jobject["Value"]["Value"].ToObject<Employee>();

                // Assert
                Assert.IsNotNull(employee);
                Assert.AreEqual(empEmail, employee.Email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
