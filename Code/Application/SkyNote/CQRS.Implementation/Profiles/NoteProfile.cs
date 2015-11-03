using AutoMapper;
using CQRS.Implementation.Models;
using DataAccessDenormalized;

namespace CQRS.Implementation.Profiles
{
    public class NoteProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<note, NoteDTO>();
        }
    }
}
