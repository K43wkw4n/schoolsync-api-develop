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

        public DivisionController(IDivision division)
        {
            _division = division; 
        }

        [HttpPost("create-division")]
        public async Task<IActionResult> CreateDivision([FromForm] Division division)
        {
            var response = await _division.CreateDivisionAsync(division);
            return Ok(response);
        }

        [HttpGet("fetch-one/{divisionCode:int}")]
        public async Task<ActionResult<Division>> GetDivisionByID(int divisionCode)
        {
            try
            {
                var result = await _division.GetDivisionByID(divisionCode);

                if(result == null)
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
            var response = await _division.FetchAll(pageSize, currentPage);
            return Ok(response);
        }

        [HttpDelete("{divisionCode:int}")]
        public async Task<IActionResult> DeleteData(int divisionCode)
        {
            try
            {
                var response = await _division.DeleteDataAsync(divisionCode);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut("update-division")]
        public async Task<ActionResult<Division>> updateData(int divisionCode, [FromForm] Division division)
        {
            try
            {
                var checkData = await _division.GetDivisionByID(divisionCode);

                if(checkData == null)
                {
                    return NotFound($"Division with divisionCode = {divisionCode} not found");
                }else
                {
                    return await _division.UpdateData(divisionCode, division);
                }
            }catch(Exception e)
            {
                return BadRequest("Internal server error " + e.Message);
            }
        }


    }
}
