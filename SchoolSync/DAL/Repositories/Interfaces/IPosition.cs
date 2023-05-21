using SchoolSync.DAL.Entities;

namespace SchoolSync.DAL.Repositories.Interfaces
{
    public interface IPosition
    {
        Task<string> CreatePositionAsync(Position position);
        Task<ResponsePagination> FetchAll(int pageSize, int currentPage);
        Task<bool> DeleteData(string id); 
    }
}
