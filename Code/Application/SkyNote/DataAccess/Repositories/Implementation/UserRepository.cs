using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementation
{
    public class UserRepository : RepositoryBase<user, skynotedbEntities1>
    {
        public UserRepository(skynotedbEntities1 context)
            :base(context)
        {

    }
}
}
