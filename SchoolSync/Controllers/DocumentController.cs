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
    public class DocumentController : ControllerBase
    {
        private readonly SchoolSyncDbContext _context;
        private readonly IDocument _document;
        public DocumentController(IDocument document,SchoolSyncDbContext context)
        {
            _document = document;
            _context = context;
        }

        [HttpPost("create-document")]
        public async Task<IActionResult> CreateDocument([FromForm] Documents documents)
        {
            var response = await _document.CreateDocumentAsync(documents);
            return Ok(response);
        }

        [HttpGet("fetch")]
        public async Task<IActionResult> FetchAll(int pageSize = 10, int currentPage = 1)
        {
            var response = await _document.FetchAll(pageSize, currentPage);
            return Ok(response);
        }

    }
}