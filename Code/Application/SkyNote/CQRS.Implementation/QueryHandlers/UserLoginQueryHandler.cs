using CQRS.Implementation.Models;
using CQRS.Implementation.Queries;
using CQRS.QueryHandlers;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation.QueryHandlers
{
    public class UserLoginQueryHandler : IQueryHandler<UserLoginQuery, UserLoginQueryResult>
    {
        private IUserRepository userRepository;

        public UserLoginQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserLoginQueryResult Handle(UserLoginQuery handle)
        {
            UserLoginQueryResult result = new UserLoginQueryResult();
            var user = userRepository.GetAllQueryable().FirstOrDefault(x => x.Login == handle.UserName);

            if(user != null)
            {
                if (user.Password.Equals(handle.Password))
                {
                    result.loginResult = new LoginResultDTO(user.UserID, user.Name);
                }
                else
                {
                    result.loginResult = new LoginResultDTO("Login and Password don't match");
                }
            }
            else
            {
                result.loginResult = new LoginResultDTO("No user with that login exist.");
            }

            return result;
        }
    }
}
