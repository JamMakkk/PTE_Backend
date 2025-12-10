using AutoMapper;
using DataContext.PTEContext;
using PTE_Model;


namespace PTE_AutoMapper
{
    public class WfdProfile : Profile
    {
        public WfdProfile()
        {
            CreateMap<WriteFromDictation, WfdModel>().ReverseMap();
            CreateMap<WriteFromDictation, CreateWfdModel>().ReverseMap();
            CreateMap<WriteFromDictation, UpdateWfdModel>().ReverseMap();
            CreateMap<WfdModel, CreateWfdModel>().ReverseMap();
            CreateMap<WfdModel, UpdateWfdModel>().ReverseMap();
            CreateMap<CreateWfdModel, UpdateWfdModel>().ReverseMap();
        }
    }
}
