
using PTE_Model;

namespace PTE_Repository
{
    public interface IWfdService
    {
        Task<WfdModel> GetWfdById(int id);
        Task<PaginationModel<WfdModel>> GetWfds(int skip, int take, SearchWfdModel search);
    }
}
