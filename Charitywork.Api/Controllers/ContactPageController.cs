using CharityWork.Core.Models;
using CharityWork.Core.Services;
using CharityWork.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPageController : ControllerBase
    {
        private readonly IContactPageService _contactPageService;
        public ContactPageController(IContactPageService contactPageService)
        {
            _contactPageService = contactPageService;
        }
        [HttpPost]
        public void createContactPage(ContactUsPage contactUsPage)
        {
            _contactPageService.createContactPage(contactUsPage);
        }
        [HttpGet("{id}")]
        public IActionResult getContact(int id)
        {
            var contact = _contactPageService.getContact(id);
            if (contact == null) {
                return NotFound();
            }else
                return Ok(contact);
			
        }
        [HttpPut("Update")]
        public void updateContactPage(ContactUsPage contactUsPage)
        {
           _contactPageService.updateContactPage(contactUsPage);
        }
        [HttpDelete("{id}")]
        public void deleteContactPage(int id)
        {
            _contactPageService.deleteContactPage(id);
        }
    }
}
