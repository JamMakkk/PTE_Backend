using Microsoft.EntityFrameworkCore;
using System.Runtime;
using System.Transactions;
using DataContext.PTEContext;
using Microsoft.Extensions.Logging;
using PTE_Model;
using AutoMapper;

namespace PTE_Repository
{
    public class WfdService : IWfdService
    {
        private readonly PTEContext _context;
        private readonly ILogger<WfdService> _logger;
        private readonly IMapper _mapper;

        public WfdService(PTEContext context, ILogger<WfdService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<WfdModel> GetWfdById(int id)
        {
            try
            {
                var service = await _context.WriteFromDictations.Where(e => e.Id == id).FirstAsync();
                var mapped = _mapper.Map<WfdModel>(service);

                return mapped;
            }
            catch (Exception ex)
            {
                var errMsg = $"Error occurred while fetching Wfd. Error: {ex.Message}";
                _logger.LogError(ex, errMsg);
                throw new Exception(errMsg);
            }

        }

        public async Task<PaginationModel<WfdModel>> GetWfds(int skip, int take, SearchWfdModel search)
        {
            try
            {
                List<WriteFromDictation> res;

                var query = _context.WriteFromDictations.AsQueryable();

                if (search.IsTested.HasValue && search.IsTested == true) query = query.Where(e => e.IsTested == true);
                if (!string.IsNullOrEmpty(search.Content)) query = query.Where(e => e.Content.Contains(search.Content));

                query = query.OrderBy(e => e.SeqNo);

                var totalCount = query.Count();

                if (skip == 0 && take == 0) res = await query.ToListAsync();
                else res = await query.Skip(skip).Take(take).ToListAsync();

                var items = _mapper.Map<List<WfdModel>>(res);

                return new() { Items = items, TotalCount = totalCount };
            }
            catch (Exception ex)
            {
                var errMsg = $"Error occurred while searching Wfd. Error: {ex.Message}";
                _logger.LogError(ex, errMsg);
                throw new Exception(errMsg);
            }
        }
    }
}