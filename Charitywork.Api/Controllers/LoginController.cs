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
    public Task<IEnumerable<UserLogin>> AllLogin() {

			return _loginService.AllLogin();
		}
		[HttpPost]
        [Route("CreateLogin")]
        public void CreateLogin(UserLogin login) {
			_loginService.CreateLogin(login);
		}

		[HttpDelete]
        [Route("DeleteLogin/{id}")]
        public void DeleteLogin(int id) {
			_loginService.DeleteLogin(id);
		}

		[HttpGet]
        [Route("GetLoginById/{id}")]
        public Task<UserLogin> GetLogin(int id) {
			return _loginService.GetLogin(id);
		}
		[HttpPost]
        [Route("UpdateLogin")]
        public void UpdateLogin(UserLogin login) {
			_loginService.UpdateLogin(login);

		}
	}
}
