
using PTE_Model;

namespace PTE_Repository
{
    public interface IWfdService
    {
        Task<WfdModel> GetWfdById(int id);
        Task<WfdModel> CreateWfd(CreateWfdModel create);
        Task<WfdModel> UpdateWfd(UpdateWfdModel update);
        Task<GeneralResponse<string>> DeleteWfdById(int id);
        Task<PaginationModel<WfdModel>> GetWfds(int skip, int take, SearchWfdModel search);

        Task<bool> UploadFile(Stream file);
    }
}
