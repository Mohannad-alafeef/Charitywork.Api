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
		public async Task<IActionResult> CreateAccount(UserAccount userAccount) {

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
		public async Task<IActionResult> GetById(int id) {
			var account = await _accountService.GetById(id);
			if (account == null) {
				return NotFound();
			}
			return Ok(account);
		}
		[HttpPost("update")]
		public void UpdateAccount(UserAccount userAccount) {
			_accountService.UpdateAccount(userAccount);
		}
		[HttpPost("UploadImage")]
		public async Task<UserAccount> UploadImage() {
			var userAccount = new UserAccount();
			var file = Request.Form.Files[0];


			var extention = Path.GetExtension(file.FileName);
			var fileName = Guid.NewGuid().ToString() + extention;
			var fullPath = Path.Combine("E:\\Anguler\\final project\\Charitywork\\src\\assets\\Images", fileName);

			using (var stream = new FileStream(fullPath, FileMode.Create)) {
				await file.CopyToAsync(stream);
			}   

			userAccount.ImagePath = fileName;
			return userAccount;

		}



	}
}
