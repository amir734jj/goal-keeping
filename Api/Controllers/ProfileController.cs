using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels.Api;

namespace Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [ApiController]
    [Route("Api/[controller]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IProfileLogic _profileLogic;
        private readonly IUserLogic _userLogic;

        public ProfileController(UserManager<User> userManager, IProfileLogic profileLogic, IUserLogic userLogic)
        {
            _userManager = userManager;
            _profileLogic = profileLogic;
            _userLogic = userLogic;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var profile = await _profileLogic.Get(user);
            
            return Ok(profile);
        }
        
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Update([FromBody] ProfileViewModel profileViewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            await _profileLogic.Update(user, profileViewModel);

            return RedirectToAction("Index");
        }
    }
}