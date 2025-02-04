using AutoMapper;
using Develop.Store.Domain.DTO;
using Develop.Store.Domain.Models;

namespace Develop.Store.Web.Api.AutoMapper
{
    public class AutoMapperManager : Profile
    {
        public AutoMapperManager() 
        {
            CreateMap<SaleDTO, Sale>();

            //.ForMember(dest => dest.Id, u => u.MapFrom(orig => orig.UseId));
        }
    }
}
