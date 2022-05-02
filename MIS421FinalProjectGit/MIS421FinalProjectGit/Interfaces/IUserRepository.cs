using MIS421FinalProjectGit.Models;

namespace MIS421FinalProjectGit.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> GetUserById(string id);
        bool Add(ApplicationUser user);
        bool Update(ApplicationUser user);
        bool Delete(ApplicationUser user);
        bool Save();
    }
}
