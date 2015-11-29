using AutoMapper;
using CQRS.Events;
using CQRS.Implementation.Events;
using CQRS.Implementation.Models;
using DataAccessDenormalized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.Profiles
{
    public class InviteProfile:Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<UserFriendInviteEvent, invites>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            Mapper.CreateMap<invites, FriendInviteDTO>();
        }
    }
}
