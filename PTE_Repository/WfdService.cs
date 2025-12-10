using Microsoft.EntityFrameworkCore;
using System.Runtime;
using System.Transactions;
using DataContext.PTEContext;
using PTE_Model;

namespace PTE_Repository
{
    public class WfdService
    {
        private readonly PTEContext _context;
        public WfdService(PTEContext context)
        {
            _context = context;
        }

        public async Task<WfdModel> GetWfdById(int id)
        {
            try
            {
                var service = await _context.WriteFromDictations.Where(e => e.Id == id).FirstAsync();

                return new WfdModel() { Id = service.Id, Content = service.Content, SeqNo = service.SeqNo, IsTested = service.IsTested };
            }
            catch (Exception ex)
            {
                var errMsg = $"Error occurred while fetching acupuncture point. Error: {ex.Message}";
                throw new Exception(errMsg);
            }

        }
    }
}