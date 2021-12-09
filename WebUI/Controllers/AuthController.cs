using Business.Abstract;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
		public AuthController(IAuthService authService, IUserService userService)
		{
			_authService = authService;
			_userService = userService;
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

			var operationClaims = _userService.GetClaims(userToLogin.Data).Data;

			var claims = new List<Claim>();
			claims.AddEmail(userToLogin.Data.Email);
			claims.AddName($"{userToLogin.Data.FirstName} {userToLogin.Data.LastName}");
			claims.AddNameIdentifier(userToLogin.Data.Id.ToString());
			claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
			

			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
			await HttpContext.SignInAsync(claimsPrincipal);

			return RedirectToAction("Index", "Home");
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
