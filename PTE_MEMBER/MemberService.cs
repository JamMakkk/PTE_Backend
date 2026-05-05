using AutoMapper;
using DataContext.PTEContext;
using Microsoft.Extensions.Logging;
using PTE_Model;

namespace PTE_MEMBER
{
    public class MemberService
    {
        private readonly PTEContext _context;
        private readonly ILogger<MemberService> _logger;
        private readonly IMapper _mapper;

        public MemberService(PTEContext context, ILogger<MemberService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<MemberModel> GetMemberById(int id, int memberId)
        {
            try
            {
                if (id != memberId) throw new Exception();

            }
            catch (Exception ex)
            {
                var errMsg = $"Error occurred while fetching member. Error: {ex.Message}";
                _logger.LogError(ex, errMsg);
                throw new Exception(errMsg);
            }
        }



    }
}
