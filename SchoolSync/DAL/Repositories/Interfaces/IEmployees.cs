using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSync.DAL.Entities;

namespace SchoolSync.DAL.Repositories.Interfaces
{
    public interface IEmployees
    {
        Task<string> CreateEmployeeAsync(Employees employees);
        Task<Employees> GetEmployeeByID(int code);
        Task<ResponsePagination> FetchAll(int pageSize, int currentPage);
        Task<bool> DeleteData(int code);
        Task<Employees> UpdateData(int Code, Employees employees);

    }
}