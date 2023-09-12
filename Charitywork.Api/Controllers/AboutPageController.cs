using CharityWork.Core.Models;
using CharityWork.Core.Services;
using CharityWork.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutPageController : ControllerBase
    {
        private readonly IAboutPageService _aboutPageService;
        public AboutPageController(IAboutPageService aboutPageService)
        {
            _aboutPageService = aboutPageService;
        }
        [HttpPost]
        public void createAboutPage(AboutUsPage aboutUsPage)
        {
            _aboutPageService.createAboutPage(aboutUsPage);
        }
        [HttpGet("{id}")]
        public AboutUsPage getAbout(int id)
        {
           return _aboutPageService.getAbout(id);
        }
        [HttpPut("Update")]
        public void updateAboutPage(AboutUsPage aboutUsPage)
        {
            _aboutPageService.updateAboutPage(aboutUsPage);
        }
        [HttpDelete("{id}")]
        public void deleteAboutPage(int id)
        {
            _aboutPageService.deleteAboutPage(id);
        }
        [Route("uploadImage")]
        [HttpPost]
        public AboutUsPage UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() +
            "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            AboutUsPage item = new AboutUsPage();
            item.ImagePath = fileName;
            return item;
        }

    }
}
