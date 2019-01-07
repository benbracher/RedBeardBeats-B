using RedStarter.Database.DataContract.Authorization.RAOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Database.DataContract.Authorization.Interfaces
{
    public interface IAuthRepository
    {
        Task<ReceivedExistingUserRAO> Register(RegisterUserRAO regUserRAO, string password);
        Task<ReceivedExistingUserRAO> Login(QueryForExistingUserRAO queryRao);
        Task<bool> UserExists(string username);
        Task<ReceivedExistingUserRAO> GetUserById(int ownerId);
    }
}
