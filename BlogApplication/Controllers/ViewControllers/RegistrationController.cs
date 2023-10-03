using AutoMapper;
using BlogApplication.Model;
using BlogApplication.Contracts.Models.Users;
using BlogApplication.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers.ViewControllers
{
  
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Identity.UserManager<UserRequest> _userManager;
        private readonly Microsoft.AspNetCore.Identity.SignInManager<UserRequest> _signInManager;
        private readonly UserController _user;

        /// <summary>
        /// Метод для регистрации нового пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<RegisterViewModel, UserRequest>(model);
                await _user.CreateUser(user);

                var result = await _userManager.CreateAsync(user, model.PasswordReg);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return View("Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View("Home");
        }
    }
}
