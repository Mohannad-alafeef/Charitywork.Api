using CharityWork.Core.Models;
using CharityWork.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase {

		private readonly ILoginService _loginService;

		public LoginController(ILoginService loginService) {
			_loginService = loginService;
		}

		[HttpGet]
        [Route("GetAllLogin")]
        public Task<IEnumerable<UserLogin>> allLogin() {
			return _loginService.allLogin();
		}
		[HttpPost]
        [Route("CreateLogin")]
        public void createLogin(UserLogin login) {
			_loginService.createLogin(login);
		}

		[HttpDelete]
        [Route("DeleteLogin/{id}")]
        public void deleteLogin(int id) {
			_loginService.deleteLogin(id);
		}

		[HttpGet]
        [Route("GetLoginById/{id}")]
        public Task<UserLogin> getLogin(int id) {
			return _loginService.getLogin(id);
		}
		[HttpPost]
        [Route("UpdateLogin")]
        public void updateLogin(UserLogin login) {
			_loginService.updateLogin(login);
		}
	}
}
