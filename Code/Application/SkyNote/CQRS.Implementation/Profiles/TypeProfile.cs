using AutoMapper;
using CQRS.Implementation.Models;
using DataAccess;

namespace CQRS.Implementation.Profiles
{
    public class TypeProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<types, TypeDTO>();
        }
    }
}
