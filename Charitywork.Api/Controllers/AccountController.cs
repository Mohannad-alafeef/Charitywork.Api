using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase {

		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService) {
			
			_accountService = accountService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAccount([FromForm]UserAccount userAccount) {
			//testdw
			var file = Request.Form.Files[0];
			var extention = Path.GetExtension(file.FileName);
			var fileName = Guid.NewGuid().ToString() + extention;
			var fullPath = Path.Combine("Images", fileName);

			using (var stream = new FileStream(fullPath, FileMode.Create)) {
				await file.CopyToAsync(stream);
			}
			
			userAccount.ImagePath = fullPath;
			_accountService.CreateAccount(userAccount);
			return Ok(userAccount);
		}
		[HttpDelete("{id}")]
		public void DeleteAccount(int id) {
			_accountService.DeleteAccount(id);
		}

		[HttpGet]
		public Task<IEnumerable<UserAccount>> GetAll() {
			return _accountService.GetAll();
		}
		[HttpGet("{id}")]
		public Task<UserAccount> GetById(int id) {
			return _accountService.GetById(id);
		}
		[HttpPost("update")]
		public void UpdateAccount(UserAccount userAccount) {
			_accountService.UpdateAccount(userAccount);
		}
		
		

		
	}
}
