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

        public async Task<Employees> GetEmployeeByID(int code) 
        {
            var query = await _context.Employees.FirstOrDefaultAsync(x => x.EmpCode == code);
            return query; 
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
            var result = await _context.Employees.FirstOrDefaultAsync(x => x.EmpCode == code);

            if (result != null)
            {
                _context.Employees.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            } 
        }

        public async Task<Employees> UpdateData(int code, Employees employees)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(x => x.EmpCode == code);

            if (result != null)
            {
                result.InitialCode = employees.InitialCode;
                result.Firstname = employees.Firstname;
                result.Lastname = employees.Lastname;
                result.MobilePhone = employees.MobilePhone;
                result.Email = employees.Email;
                result.Address = employees.Address;
                result.Subdistrict = employees.Subdistrict;
                result.District = employees.District;
                result.Province = employees.Province;
                result.Postcode = employees.Postcode;
                result.Username = employees.Username;
                result.Password = employees.Password;
                result.CreatedDate = employees.CreatedDate;
                result.IsUsed = employees.IsUsed;
                result.DivisionCode = employees.DivisionCode;

                _context.Entry(result).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return result;
            }
            else
            {
                return null;
            }
        }


    }
}
