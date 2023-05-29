using SchoolSync.DAL.Entities;

namespace SchoolSync.DAL.Repositories.Interfaces
{
    public interface IDivision
    {
        Task<string> CreateDivisionAsync(Division division);
        Task<Division> GetDivisionByID(int DivisionCode);
        Task<ResponsePagination> FetchAll(int pageSize, int currentPage);
        Task<bool> DeleteData(int id); 
        Task<bool> DeleteDataAsync(int divisionCode);
        Task<Division> UpdateData(int divisionCode, Division division);
    }
}
