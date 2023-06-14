using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSync.DAL.EFCore;
using SchoolSync.DAL.Entities;
using SchoolSync.DAL.Repositories.Interfaces;

namespace SchoolSync.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    { 
        private readonly IEmployees _employees;
        public EmployeeController(IEmployees employees)
        {
            _employees = employees; 
        }

        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateDocument([FromForm] Employees employees)
        {
            var response = await _employees.CreateEmployeeAsync(employees);
            return Ok(response);
        }

        [HttpGet("fetch-one/{Code:int}")]
        public async Task<ActionResult<Employees>> GetEmployeeByID(int Code)
        {
            try
            {
                var result = await _employees.GetEmployeeByID(Code);

                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("fetch")]
        public async Task<IActionResult> FetchAll(int pageSize = 10, int currentPage = 1)
        {
            var response = await _employees.FetchAll(pageSize, currentPage);
            return Ok(response);
        }

        [HttpDelete("{code:int}")]
        public async Task<IActionResult> DeleteData(int code)
        {
            try
            {
                var response = await _employees.DeleteData(code);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut("update-Employee")]
        public async Task<ActionResult<Employees>> updateData(int code, [FromForm] Employees employees)
        {
            try
            {
                var checkData = await _employees.GetEmployeeByID(code);

                if (checkData == null)
                {
                    return NotFound($"Division with divisionCode = {code} not found");
                }
                else
                {
                    return await _employees.UpdateData(code, employees);
                }
            }
            catch (Exception e)
            {
                return BadRequest("Internal server error " + e.Message);
            }
        }


    }
}