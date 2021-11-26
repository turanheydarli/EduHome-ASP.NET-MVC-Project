using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
	public class AuthController : Controller
	{
		IAuthService _authService;
		IUserService _userService;
		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
		{
			var userToLogin = await _authService.Login(userForLoginDto);
			if (!userToLogin.Success)
			{
				return Content(userToLogin.Message);
			}

			var token = _authService.CreateAccessToken(userToLogin.Data);

			return Ok(token.Data);
		}

		public IActionResult Register()
		{
			if (User.Identity.IsAuthenticated)
			{
				return NotFound();
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
		{
			var userToRegister = await _authService.Register(userForRegisterDto);
			if (!userToRegister.Success)
			{
				return Content(userToRegister.Message);
			}

			var token = _authService.CreateAccessToken(userToRegister.Data);

			return Content(userForRegisterDto.FirstName + token);
		}
	}
}
