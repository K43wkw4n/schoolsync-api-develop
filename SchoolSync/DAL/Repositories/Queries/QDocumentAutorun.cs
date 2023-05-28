using Microsoft.EntityFrameworkCore;
using SchoolSync.DAL.EFCore;
using SchoolSync.DAL.Entities;
using SchoolSync.DAL.Helper;
using SchoolSync.DAL.Repositories.Interfaces;

namespace SchoolSync.DAL.Repositories.Queries
{
    public class QDocumentAutorun : IDocumentAutorun
    {
        private readonly SchoolSyncDbContext _context;
        public QDocumentAutorun(SchoolSyncDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateDocumentAutorunAsync(DocumentAutorun documentAutorun)
        { 
            await _context.DocumentAutoruns.AddAsync(documentAutorun);
            await _context.SaveChangesAsync();
            return "เพิ่มข้อมูลเรียบร้อยแล้ว";
        }

        public async Task<ResponsePagination> FetchAll(int pageSize, int currentPage)
        {  
            var query = await _context.DocumentAutoruns.ToListAsync<dynamic>();

            Pagination pagination = new Pagination(query, currentPage, pageSize);
 
            return new ResponsePagination
            {
                StatusCode = 200,
                TaskStatus = true,
                Message = "สำเร็จ",
                Pagin = new
                {
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalRows = pagination.TotalRow,
                    TotalPages = pagination.TotalPage
                },
                Data = pagination.Data
            };
        }
    }
}