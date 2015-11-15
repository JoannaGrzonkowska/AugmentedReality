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
            Mapper.CreateMap<group, UserGroupDTO>();
            Mapper.CreateMap<group, GroupMemberDTO>();
            Mapper.CreateMap<group, FriendDTO>();
            Mapper.CreateMap<Event, group>()
                .Include<GroupCreatedEvent, group>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.AggregateId));

            //User create Group
            Mapper.CreateMap<GroupCreatedEvent, group>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.GroupName));

            //User join Group
            Mapper.CreateMap<UserJoinGroupEvent, group>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

            //User add Friend
            Mapper.CreateMap<UserAddFriendEvent, group>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
