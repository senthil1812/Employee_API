using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using BusinessModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness<Employee> _employeeBusiness;

        public EmployeeController(IEmployeeBusiness<Employee> employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            JsonResult result = new JsonResult(null);
            try
            {
                var employeeList = _employeeBusiness.GetAll();
                if (employeeList != null)
                {
                    result.Value = employeeList;
                    result.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return StatusCode((int)System.Net.HttpStatusCode.OK, result);
                }
                else
                {
                    result.Value = "No records found!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return StatusCode((int)System.Net.HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
                result.Value = ex.Message;
                result.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, result);
            }
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            JsonResult result = new JsonResult(null);
            try
            {
                #region Precondition Checks

                if (id == null || id == 0)
                {
                    result.Value = "User id is required!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.PreconditionFailed;
                    return StatusCode((int)System.Net.HttpStatusCode.PreconditionFailed, result);
                }
                #endregion
                var empDetail = _employeeBusiness.Select(id);
                if (empDetail.Data != null)
                {
                    result.Value = empDetail.Data;
                    result.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return StatusCode((int)System.Net.HttpStatusCode.OK, result);
                }
                else
                {
                    result.Value = "No records found!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return StatusCode((int)System.Net.HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
                result.Value = ex.Message;
                result.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Employee model)
        {

            JsonResult result = new JsonResult(null);
            try
            {
                #region Precondition Checks
                if (model == null)
                {
                    result.Value = "The request object is empty and is required.!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.PreconditionFailed;
                    return StatusCode((int)System.Net.HttpStatusCode.PreconditionFailed, result);
                }
                if (string.IsNullOrEmpty(model.FirstName))
                {
                    result.Value = "FirstName is required!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.PreconditionFailed;
                    return StatusCode((int)System.Net.HttpStatusCode.PreconditionFailed, result);
                }
                if (string.IsNullOrEmpty(model.LastName))
                {
                    result.Value = "LastName is required!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.PreconditionFailed;
                    return StatusCode((int)System.Net.HttpStatusCode.PreconditionFailed, result);
                }

                #endregion
                var createresult = await _employeeBusiness.CreateAsync(model);
                if (createresult.IsSuccess)
                {
                    result.Value = createresult.Data;
                    result.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return StatusCode((int)System.Net.HttpStatusCode.OK, result);
                }
                else
                {
                    result.Value = "Issue while employee insert!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return StatusCode((int)System.Net.HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
                result.Value = ex.Message;
                result.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, result);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employee model)
        {
            JsonResult result = new JsonResult(null);
            try
            {
                #region Precondition Checks
                if (model == null)
                {
                    result.Value = "The request object is empty and is required.!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.PreconditionFailed;
                    return StatusCode((int)System.Net.HttpStatusCode.PreconditionFailed, result);
                }
                if (string.IsNullOrEmpty(model.FirstName))
                {
                    result.Value = "FirstName is required!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.PreconditionFailed;
                    return StatusCode((int)System.Net.HttpStatusCode.PreconditionFailed, result);
                }
                if (string.IsNullOrEmpty(model.LastName))
                {
                    result.Value = "LastName is required!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.PreconditionFailed;
                    return StatusCode((int)System.Net.HttpStatusCode.PreconditionFailed, result);
                }

                #endregion
                var updateresult = _employeeBusiness.Update(model);
                if (updateresult.Data != null)
                {
                    result.Value = updateresult;
                    result.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return StatusCode((int)System.Net.HttpStatusCode.OK, result);
                }
                else
                {
                    result.Value = "Issue while update employee detail!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    return StatusCode((int)System.Net.HttpStatusCode.BadRequest, result);
                }
            }
            catch (Exception ex)
            {
                result.Value = ex.Message;
                result.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, result);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            JsonResult result = new JsonResult(null);
            try
            {
                #region Precondition Checks

                if (id == null || id == 0)
                {
                    result.Value = "User id is required!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.PreconditionFailed;
                    return StatusCode((int)System.Net.HttpStatusCode.PreconditionFailed, result);
                }
                #endregion
                var detail = _employeeBusiness.Select(id);
                detail.Data.IsDeleted = true;
                var updateEmployee = _employeeBusiness.Update(detail.Data);
                if (updateEmployee.Data != null)
                {
                    result.Value = "Employee Deleted Successfully!"; ;
                    result.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return StatusCode((int)System.Net.HttpStatusCode.OK, result);
                }
                else
                {
                    result.Value = "Issue while delete the employee!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    return StatusCode((int)System.Net.HttpStatusCode.BadRequest, result);
                }
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                result.Value = ex.Message;
                result.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, result);
            }
        }


        [HttpGet("GetbyEmail/{email}")]
        public IActionResult SelectbyEmail(string email)
        {
            JsonResult result = new JsonResult(null);
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    result.Value = "Email is required!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.PreconditionFailed;
                    return StatusCode((int)System.Net.HttpStatusCode.PreconditionFailed, result);
                }
                var empDetail = _employeeBusiness.SelectbyEmail(email);
                if (empDetail.Data != null)
                {
                    result.Value = empDetail.Data;
                    result.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return StatusCode((int)System.Net.HttpStatusCode.OK, result);
                }
                else
                {
                    result.Value = "No records found!";
                    result.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    return StatusCode((int)System.Net.HttpStatusCode.OK, result);
                }
            }
            catch (Exception ex)
            {
                result.Value = ex.Message;
                result.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, result);
            }
        }
    }
}