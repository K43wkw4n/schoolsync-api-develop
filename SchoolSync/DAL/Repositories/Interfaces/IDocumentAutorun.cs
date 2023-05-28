using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSync.DAL.Entities;

namespace SchoolSync.DAL.Repositories.Interfaces
{
    public interface IDocumentAutorun
    {
        Task<string> CreateDocumentAutorunAsync(DocumentAutorun documentAutorun);
        Task<ResponsePagination> FetchAll(int pageSize, int currentPage);
    }
}