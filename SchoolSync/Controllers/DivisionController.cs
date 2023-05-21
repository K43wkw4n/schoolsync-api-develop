using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSync.DAL.EFCore;
using SchoolSync.DAL.Entities;
using SchoolSync.DAL.Repositories.Interfaces;

namespace SchoolSync.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    { 
        private readonly IDivision _division;
        private readonly SchoolSyncDbContext _context;
        public DivisionController(IDivision division,SchoolSyncDbContext context)
        {
            _context = context;
            _division = division; 
        }

        [HttpPost("create-division")]
        public async Task<IActionResult> CreateDivision([FromForm] Division division)
        {
            var response = await _division.CreateDivisionAsync(division);
            return Ok(response);
        }

        [HttpGet("fetch")]
        public async Task<IActionResult> FetchAll(int pageSize = 10, int currentPage = 1)
        {
            var response = await _division.FetchAll(pageSize, currentPage);
            return Ok(response);
        }
    }
}
