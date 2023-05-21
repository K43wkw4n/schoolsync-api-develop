using Microsoft.EntityFrameworkCore;
using SchoolSync.DAL.EFCore;
using SchoolSync.DAL.Entities;
using SchoolSync.DAL.Repositories.Interfaces;

namespace SchoolSync.DAL.Repositories.Queries
{
    public class QPosition : IPosition
    {
        private readonly SchoolSyncDbContext _context;
        public QPosition(SchoolSyncDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreatePositionAsync(Position position)
        {
            var division = _context.Division.FindAsync(position.DivisionCode);

            if(division == null) return "Your DivisionCode is not exist";

            var positions = new Position()
            {
                PositionName = position.PositionName, 
                CreateDate = DateTime.Now,
                DivisionCode = position.DivisionCode,
                IsUsed = position.IsUsed,
            };
            
            await _context.Position.AddAsync(positions);
            await _context.SaveChangesAsync();
            return "เพิ่มข้อมูลเรียบร้อยแล้ว";
        }

        public async Task<ResponsePagination> FetchAll(int pageSize, int currentPage)
        {
            var query = await _context.Position.Include(x=>x.Division).ToListAsync();

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
        public async Task<bool> DeleteData(string id)
        {
            var query = _context.Position.FirstOrDefault(x => x.PositionCode == id);
            query.IsUsed = query.IsUsed == "1" ? "0" : "1";
            _context.Entry(query).State = EntityState.Modified;
            int save = await _context.SaveChangesAsync();
            if (save > 0)
            {
                return true;
            }else{
                return false;
            }
        }
    }
}
