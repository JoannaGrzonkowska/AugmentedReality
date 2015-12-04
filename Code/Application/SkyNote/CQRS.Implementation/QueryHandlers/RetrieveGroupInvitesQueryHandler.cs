using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccessDenormalized.Repository;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CQRS.Implementation.QueryHandlers
{
    public class RetrieveGroupInvitesQueryHandler : IQueryHandler<RetrieveGroupInvitesQuery, RetrieveGroupInvitesQueryResult>
    {
        private readonly IInvitesDenormalizedRepository invitesRepository;

        public RetrieveGroupInvitesQueryHandler(IInvitesDenormalizedRepository invitesRepository)
        {
            this.invitesRepository = invitesRepository;
        }

        public RetrieveGroupInvitesQueryResult Handle(RetrieveGroupInvitesQuery handle)
        {
            RetrieveGroupInvitesQueryResult result = new RetrieveGroupInvitesQueryResult();
            var groupInvates = invitesRepository.GetAllQueryable().Where(x => x.FriendId == handle.InvitedUserId && x.GroupId != null && x.State == "PENDING").ToList(); //CHANGE ! x.UserId == handle.UserId && x.FriendId != null

            result.GroupInvates = Mapper.Map<IEnumerable<GroupInviteDTO>>(groupInvates);

            return result;
        }
    }
}
