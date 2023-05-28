using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSync.DAL.EFCore;
using SchoolSync.DAL.Entities;
using SchoolSync.DAL.Helper;
using SchoolSync.DAL.Repositories.Interfaces;

namespace SchoolSync.DAL.Repositories.Queries
{
    public class QEmployees : IEmployees
    {
        private readonly SchoolSyncDbContext _context;
        public QEmployees(SchoolSyncDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateEmployeeAsync(Employees employees)
        {
            await _context.Employees.AddAsync(employees);
            await _context.SaveChangesAsync();
            return "เพิ่มข้อมูลเรียบร้อยแล้ว";
        }

        public async Task<ResponsePagination> FetchAll(int pageSize, int currentPage)
        {
            var query = await _context.Employees.ToListAsync<dynamic>();

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

        public async Task<bool> DeleteData(int code)
        {
            var query = _context.Employees.FirstOrDefault(x => x.EmpCode == code);
            query.IsUsed = query.IsUsed == "1" ? "0" : "1";
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

    }
}