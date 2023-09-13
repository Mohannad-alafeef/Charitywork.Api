using CharityWork.Core.Models;
using CharityWork.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase {
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService) {
			_contactService = contactService;
		}

		[HttpPut]
		public void ChangeStatus(Contact contact) {
			_contactService.ChangeStatus(contact);
		}
		[HttpPost]
		public void CreateContact(Contact contact) {
			_contactService.CreateContact(contact);
		}
		[HttpDelete("Delete/{id}")]
		public void DeleteContact(int id) {
			_contactService.DeleteContact(id);
		}
		[HttpGet]
		public Task<IEnumerable<Contact>> GetAll() {
			return _contactService.GetAll();
		}
	}
}
