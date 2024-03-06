using Application.ViewModel;
using AutoMapper;
using Domain.Entity;

namespace Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<User , UserDto>()
            //    .ForMember(x=> x.PhotoUrl, c => c.MapFrom(b=> b.Photos.FirstOrDefault(y=> y.IsMain).Url));
            CreateMap<Product , ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
        }
    }
}
