using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class AuthManager : IAuthService
	{
		IUserService _userService;
		ITokenHelper _tokenHelper;
		public AuthManager(IUserService userService, ITokenHelper tokenHelper)
		{
			_userService = userService;
			_tokenHelper = tokenHelper;
		}
		public IDataResult<AccessToken> CreateAccessToken(User user)
		{
			var claims = _userService.GetClaims(user);
			var accessToken = _tokenHelper.CreateToken(user, claims.Data);

			return new SuccessDataResult<AccessToken>(accessToken, "Token yaradildi");
		}

		public async Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
		{
			var userToLogin = await _userService.GetByEmailAsync(userForLoginDto.Email);

			if(userToLogin.Data == null)
			{
				return new ErrorDataResult<User>("İstifadəçi tapilmadi.");
			}

			var result = BusinessRules.Run
			(
				CheckUserPassword(userToLogin.Data, userForLoginDto.Password)
			);

			if (result != null)
			{
				return new ErrorDataResult<User>(result.Message);
			}


			return new SuccessDataResult<User>(userToLogin.Data, "User login");

		}

		public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto)
		{
			var result = BusinessRules.Run
			(
				(await UserIsExistsAsync(userForRegisterDto.Email))
			);

			if (result != null)
			{
				return new ErrorDataResult<User>(result.Message);
			}

			byte[] passwordHash, passwordSalt;
			HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
			User user = new User
			{
				FirstName = userForRegisterDto.FirstName,
				LastName = userForRegisterDto.LastName,
				Email = userForRegisterDto.Email,
				PasswordHash = passwordHash,
				PasswordSalt = passwordSalt,
				Status = true
			};
			_userService.Add(user);

			return new SuccessDataResult<User>(user,"User elave edildi");
		}

		public async Task<IResult> UserIsExistsAsync(string email)
		{
			if ((await _userService.GetByEmailAsync(email)).Data != null)
			{
				return new ErrorResult("Bu istifadəçi mövcuddur");
			}

			return new SuccessResult();
		}

		private IResult CheckUserNotFound(User user)
		{
			if (user == null)
			{
				return new ErrorResult("İstifadəçi tapilmadi.");
			}

			return new SuccessResult();
		}

		private IResult CheckUserPassword(User user, string password)
		{
			var result = HashingHelper.VaidatePasswordHash(password, user.PasswordHash, user.PasswordSalt);
			if (!result)
			{
				return new ErrorResult("Şifrə yanlışdır.");
			}
			return new SuccessResult();
		}
	}
}
