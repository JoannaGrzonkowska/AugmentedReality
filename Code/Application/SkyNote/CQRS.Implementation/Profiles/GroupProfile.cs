using AutoMapper;
using CQRS.Events;
using CQRS.Implementation.Events;
using CQRS.Implementation.Models;
using DataAccessDenormalized;

namespace CQRS.Implementation.Profiles
{
    public class GroupProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<group, GroupDTO>();
            Mapper.CreateMap<Event, group>()
                .Include<GroupCreatedEvent, group>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.AggregateId));
                

            Mapper.CreateMap<GroupCreatedEvent, group>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
