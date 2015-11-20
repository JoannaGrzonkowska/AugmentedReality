using AutoMapper;
using CQRS.Implementation.Models;
using DataAccess;

namespace CQRS.Implementation.Profiles
{
    public class CategoryProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<categories, CategoryDTO>();
        }
    }
}
