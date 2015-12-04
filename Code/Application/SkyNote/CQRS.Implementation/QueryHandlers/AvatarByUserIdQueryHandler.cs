using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using AutoMapper;
using CQRS.Implementation.Models;
using System.Linq;

namespace CQRS.Implementation.QueryHandlers
{
    public class AvatarByUserIdQueryHandler : IQueryHandler<AvatarByUserIdQuery, AvatarByUserIdQueryResult>
    {
        private readonly IUserRepository userRepository;

        public AvatarByUserIdQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public AvatarByUserIdQueryResult Handle(AvatarByUserIdQuery handle)
        {
            var result = new AvatarByUserIdQueryResult();

            result.AvatarFileName = userRepository.GetById(handle.UserId).Avatar;
            return result;
        }
    }
}
