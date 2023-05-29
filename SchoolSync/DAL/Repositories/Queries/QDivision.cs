using Microsoft.EntityFrameworkCore;
using SchoolSync.DAL.EFCore;
using SchoolSync.DAL.Entities;
using SchoolSync.DAL.Helper;
using SchoolSync.DAL.Repositories.Interfaces;

namespace SchoolSync.DAL.Repositories.Queries
{
    public class QDivision : IDivision
    {
        private readonly SchoolSyncDbContext _context;
        public QDivision(SchoolSyncDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<string> CreateDivisionAsync(Division division)
        {
            await _context.Divisions.AddAsync(division);
            await _context.SaveChangesAsync();
            return "เพิ่มข้อมูลเรียบร้อยแล้ว";
        }

        public async Task<Division> GetDivisionByID(int DivisionCode)
        {
            var query = await _context.Divisions.FirstOrDefaultAsync(x=>x.DivisionCode == DivisionCode);
            return query;
        }

        public async Task<ResponsePagination> FetchAll(int pageSize, int currentPage)
        {
            var query = await _context.Divisions.ToListAsync<dynamic>();

            Pagination pagination = new Pagination(query, currentPage, pageSize);

            // int totalRow = 0;
            // totalRow = query.Count;
            // var totalPage = (double)totalRow / pageSize;
            // var value = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            // totalPage = (int)Math.Ceiling(totalPage);

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

        //ลบข้อมูล
        public async Task<bool> DeleteData(int id)
        {
            var query = _context.Divisions.FirstOrDefault(x => x.DivisionCode == id);
            query.IsUsed = query.IsUsed == true ? false : true;
            _context.Entry(query).State = EntityState.Modified;
            int save = await _context.SaveChangesAsync();
            if (save > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteDataAsync(int divisionCode)
        {
            var result = await _context.Divisions.FirstOrDefaultAsync(x=>x.DivisionCode == divisionCode);
            
            if(result != null)
            {
                _context.Divisions.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            } else
            {
                return false;
            }
        }

        public async Task<Division> UpdateData(int divisionCode, Division division)
        {
            var result = await _context.Divisions.FirstOrDefaultAsync(x=>x.DivisionCode == divisionCode);

            if(result != null)
            {
                result.DivisionName = division.DivisionName;
                result.CreatedDate = division.CreatedDate;
                result.IsUsed = division.IsUsed;

                _context.Entry(result).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return result;
            } else
            {
                return null;
            } 
        }
        
    }
}
