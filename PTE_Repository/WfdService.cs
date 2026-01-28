using Microsoft.EntityFrameworkCore;
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

        public async Task<WfdModel> CreateWfd(CreateWfdModel create)
        {
            try
            {
                var service = _mapper.Map<WriteFromDictation>(create);

                service.SeqNo = (await _context.WriteFromDictations.MaxAsync(e => e.SeqNo) ?? 0) + 1;

                await _context.WriteFromDictations.AddAsync(service);
                await _context.SaveChangesAsync();

                return await GetWfdById(service.Id);
            }
            catch (Exception ex)
            {
                var errMsg = $"Error occurred while creating Wfd. Error: {ex.Message}";
                _logger.LogError(ex, errMsg);
                throw new Exception(errMsg);
            }
        }
        public async Task<WfdModel> UpdateWfd(UpdateWfdModel update)
        {
            try
            {
                var service = await _context.WriteFromDictations.Where(e => e.Id == update.Id).FirstOrDefaultAsync()
                    ?? throw new InvalidDataException("Invalid Id");
                _mapper.Map(update, service);

                _context.WriteFromDictations.Update(service);
                await _context.SaveChangesAsync();

                return await GetWfdById(service.Id);
            }
            catch (Exception ex)
            {
                var errMsg = $"Error occurred while updating Wfd. Error: {ex.Message}";
                _logger.LogError(ex, errMsg);
                throw new Exception(errMsg);
            }
        }
        public async Task<GeneralResponse<string>> DeleteWfdById(int id)
        {
            try
            {
                var service = await _context.WriteFromDictations.Where(e => e.Id == id).ExecuteDeleteAsync();
                if (service == 0) throw new InvalidDataException("Invalid Id");

                return new() { IsSuccess = true, Response = "Successfully delete" };
            }
            catch (Exception ex)
            {
                var errMsg = $"Error occurred while deleting Wfd. Error: {ex.Message}";
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