using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Services {
	public class LoginService : ILoginService {

		private readonly ILoginRepository _loginRepository;

		public LoginService(ILoginRepository loginRepository) {
			_loginRepository = loginRepository;
		}

		public Task<IEnumerable<UserLogin>> AllLogin() {
			return _loginRepository.AllLogin();
		}

		public async Task<string?> Auth(UserLogin userLogin) {
			var result = await _loginRepository.Auth(userLogin);
			
			if (result == null) {
				return null;
			}
			else {
				var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("CharityWorkSuperSecretKey@345"));
				var signingCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

				var claims= new List<Claim> { };

                if (result.VisaCard != null)
				{
					claims = new List<Claim> {
					new Claim("userName",result.Login.UserName),
					new Claim("userId",result.UserId.ToString(),ClaimValueTypes.Integer64),
					new Claim("firstName",result.FirstName),
					new Claim("lastName",result.LastName),
					new Claim("address",result.Address),
					new Claim("age",result.Age.ToString(),ClaimValueTypes.Integer64),
					new Claim("email",result.Email),
					new Claim("gender",result.Gender),
					new Claim("phone",result.Phone),
					new Claim("ImagePath",result.ImagePath),
					new Claim("roleId",result.Login.RoleId.ToString(),ClaimValueTypes.Integer64),
					new Claim("loginDate",result.LoginDate.ToString(),ClaimValueTypes.DateTime),

					new Claim("CardNumber", result.VisaCard?.CardNumber),
					new Claim("cvv", result.VisaCard.Cvv?.ToString(), ClaimValueTypes.Integer64),
					new Claim("balance", result.VisaCard.Balance?.ToString(), ClaimValueTypes.Integer64),
					new Claim("expDate", result.VisaCard.ExpDate?.ToString(), ClaimValueTypes.DateTime)


				};
				}
				else
				{
					 claims = new List<Claim> {
					new Claim("userName",result.Login.UserName),
					new Claim("userId",result.UserId.ToString(),ClaimValueTypes.Integer64),
					new Claim("firstName",result.FirstName),
					new Claim("lastName",result.LastName),
					new Claim("address",result.Address),
					new Claim("age",result.Age.ToString(),ClaimValueTypes.Integer64),
					new Claim("email",result.Email),
					new Claim("gender",result.Gender),
					new Claim("phone",result.Phone),
					new Claim("ImagePath",result.ImagePath),
					new Claim("roleId",result.Login.RoleId.ToString(),ClaimValueTypes.Integer64),
					new Claim("loginDate",result.LoginDate.ToString(),ClaimValueTypes.DateTime),
					};
                }

                var tokenOptions = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddHours(1), signingCredentials: signingCredential);
				var token = new JwtSecurityTokenHandler();


				return token.WriteToken(tokenOptions);
			}
			
		}

		public Task<int> CreateLogin(UserLogin login) {
			return _loginRepository.CreateLogin(login);
		}

		public void DeleteLogin(int id) {
			_loginRepository.DeleteLogin(id);
		}

		public Task<UserLogin> GetLogin(int id) {
			return _loginRepository.GetLogin(id);
		}

		public void UpdateLogin(UserLogin login) {
			_loginRepository.UpdateLogin(login);
		}
	}
}
