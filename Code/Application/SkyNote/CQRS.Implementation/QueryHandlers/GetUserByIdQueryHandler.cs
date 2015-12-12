using AutoMapper;
using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccess.Repositories;

namespace CQRS.Implementation.QueryHandlers
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly IUserRepository userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public GetUserByIdQueryResult Handle(GetUserByIdQuery handle)
        {
            var result = new GetUserByIdQueryResult();
            var user = userRepository.GetById(handle.UserId);
            result.User = new UserDTO
            {
                Login = user.Login,
                Mail = user.Mail,
                Name = user.Name,
                UserID = user.UserID
            };
            return result;
        }
    }
}
