using AutoMapper;
using CQRS.Implementation.Models;
using DataAccessDenormalized;

namespace CQRS.Implementation.Profiles
{
    class UserProfile : Profile
    {
        protected override void Configure()
        {
           // Mapper.CreateMap<user, UserDTO>();// TODO
        }
    }
}
