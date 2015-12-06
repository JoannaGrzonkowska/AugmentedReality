using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccess.Repositories;
using DataAccessDenormalized.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.QueryHandlers
{
    public class GetAllPotentialFriendsQueryHandler : IQueryHandler<GetAllPotentialFriendsQuery, GetAllPotentialFriendsQueryResult>
    {
        private readonly IGroupDenormalizedRepository groupRepository;
        private readonly IUserfriendgroupRepository userfriendgroupRepository;
        private readonly IUserRepository userRepository;

        public GetAllPotentialFriendsQueryHandler(IGroupDenormalizedRepository groupRepository, IUserfriendgroupRepository userfriendgroupRepository, IUserRepository userRepository)
        {
            this.groupRepository = groupRepository;
            this.userfriendgroupRepository = userfriendgroupRepository;
            this.userRepository = userRepository;
        }

        public GetAllPotentialFriendsQueryResult Handle(GetAllPotentialFriendsQuery handle)
        {
            GetAllPotentialFriendsQueryResult result = new GetAllPotentialFriendsQueryResult();
            var userfriendgroupPair = userfriendgroupRepository.GetAllQueryable().FirstOrDefault(x => x.UserId == handle.UserId);

            if (userfriendgroupPair != null)
            {
                var friends = groupRepository.GetAllQueryable().Where(x => x.GroupId == userfriendgroupPair.GroupId && (x.Role == "Member" || x.Role == "OWNER")).ToList();

                List<int> friendsIds = new List<int>();
                foreach(var friend in friends)
                    if(((DataAccessDenormalized.group)friend).UserId != null)
                        friendsIds.Add((int)((DataAccessDenormalized.group)friend).UserId);

                var potentialFriends = userRepository.GetAllQueryable().Where(x => !friendsIds.Contains(x.UserID)).ToList();

                result.Users = Mapper.Map<IEnumerable<PotentialFriendDTO>>(potentialFriends);
            }
            return result;
        }
    }
}
