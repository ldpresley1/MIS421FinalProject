using Microsoft.EntityFrameworkCore;
using MIS421FinalProjectGit.Data;
using MIS421FinalProjectGit.Interfaces;
using MIS421FinalProjectGit.Models;

namespace MIS421FinalProjectGit.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext  context)
        {
            _context = context;
        }
        public bool Add(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
         
        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            return await _context.ApplicationUsers.ToListAsync();
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await _context.ApplicationUsers.FindAsync(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(ApplicationUser user)
        {
            _context.Update(user);
            return Save(); 
        }
    }
}
