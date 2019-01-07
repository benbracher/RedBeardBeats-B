using RedStarter.Database.DataContract.Authorization.RAOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Database.DataContract.User
{
    public interface IUserRepository
    {
        Task<ReceivedExistingUserRAO> GetUser(int userId);
    }
}
