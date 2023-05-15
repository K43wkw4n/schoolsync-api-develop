using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSync.DAL.EFCore;
using SchoolSync.DAL.Entities;
using SchoolSync.DAL.Repositories.Interfaces; 

namespace SchoolSync.DAL.Repositories.Queries
{
    public class QDivision : IDivision
    {
        private readonly SchoolSyncDbContext db;

        public QDivision(SchoolSyncDbContext dbContext)
        {
            db = dbContext;
        }

        public async Task<string> CreateDivisionAsync(Division division)
        {
            await db.Division.AddAsync(division);
            await db.SaveChangesAsync();
            return "เพิ่มข้อมูลเรียบร้อยแล้ว";
        }

        public async Task<ResponsePagination> FetchAll(int pageSize, int currentPage)
        {
            var query = await db.Division.ToListAsync();

            int totalRow = 0;
            totalRow = query.Count;
            var totalPage = (double)totalRow / pageSize;
            var value = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            totalPage = (int)Math.Ceiling(totalPage);

            return new ResponsePagination { 
                StatusCode = 200, 
                TaskStatus = true, 
                Message = "สำเร็จ", 
                Pagin = new { 
                        CurrentPage = currentPage, 
                        PageSize = pageSize, 
                        TotalRows = totalRow, 
                        TotalPages = totalPage 
                    }, 
                    Data = value 
            };

        }

        //ลบข้อมูล
        public async Task<bool> DeleteData(int id)
        {
            var query = db.Division.FirstOrDefault(x => x.DivisionCode == id);
            query.IsUsed = query.IsUsed == "1" ? "0" : "1";
            db.Entry(query).State = EntityState.Modified;
            int save = await db.SaveChangesAsync();
            if (save > 0)
            {
                return true;
            }else{
                return false;
            }
        }
	}
}
