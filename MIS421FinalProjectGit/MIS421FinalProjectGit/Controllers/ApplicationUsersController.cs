using Microsoft.AspNetCore.Mvc;
using MIS421FinalProjectGit.Interfaces;
using MIS421FinalProjectGit.Models;

namespace MIS421FinalProjectGit.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        public ApplicationUsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //Temporarily commenting this so that the code will run for office horus
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();
            List<ApplicationUserVM> result = new List<ApplicationUserVM>();

            foreach (var user in users)
            {
                var userViewModel = new ApplicationUserVM()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,

                };
                result.Add(userViewModel);
            }
            return View(result);
        }






    }
}
