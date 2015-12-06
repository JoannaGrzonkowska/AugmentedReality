using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized.Repository;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class RetrieveFriendInvitesQueryHandler : IQueryHandler<RetrieveFriendInvitesQuery, RetrieveFriendInvitesQueryResult>
    {
        private readonly IInvitesDenormalizedRepository invitesRepository;

        public RetrieveFriendInvitesQueryHandler(IInvitesDenormalizedRepository invitesRepository)
        {
            this.invitesRepository = invitesRepository;
        }

        public RetrieveFriendInvitesQueryResult Handle(RetrieveFriendInvitesQuery handle)
        {
            RetrieveFriendInvitesQueryResult result = new RetrieveFriendInvitesQueryResult();
            var friendInvites = invitesRepository.GetAllQueryable().Where(x => x.FriendId == handle.InvitedUserId && x.GroupId == null && x.State == "PENDING").ToList();

            result.FriendInvites = Mapper.Map<IEnumerable<FriendInviteDTO>>(friendInvites);

            return result;
        }
    }
}
