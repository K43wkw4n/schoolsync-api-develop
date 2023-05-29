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

        [HttpGet("fetch")]
        public async Task<IActionResult> FetchAll(int pageSize = 10, int currentPage = 1)
        {
            var response = await _employees.FetchAll(pageSize, currentPage);
            return Ok(response);
        }




    }
}