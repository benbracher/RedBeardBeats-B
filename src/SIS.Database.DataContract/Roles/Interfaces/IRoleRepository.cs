using System.Threading.Tasks;
using RedStarter.Database.DataContract.Authorization.RAOs;

namespace RedStarter.Database.DataContract.Roles.Interfaces
{
    public interface IRoleRepository
    {
        Task<bool> AddUserToRole(ReceivedExistingUserRAO User, string Role);
    }
}