using CharityWork.Core.Models;
using CharityWork.Core.Services;
using CharityWork.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly IHomePageService _homePageServices;
        
        public HomePageController(IHomePageService homePageServices) 
        {
            _homePageServices= homePageServices;
        }

        [HttpPost]
        public void createHomePage(HomePage homePage)
        {
            _homePageServices.createHomePage(homePage);
        }
        [HttpDelete("{id}")]
        public void deleteHomePage(int id)
        {
            _homePageServices.deleteHomePage(id);
        }
        [HttpGet("{id}")]
        public IActionResult getHome(int id)
        {
            var home = _homePageServices.getHome(id);
            if (home == null) {
                return NotFound();
            }else
                return Ok(home);
            
        }
        [HttpPut("Update")]
        public void updateHomePage(HomePage homePage)
        {
            _homePageServices.updateHomePage(homePage);
        }
        [Route("uploadImage")]
        [HttpPost]
        public HomePage UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() +
            "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            HomePage item = new HomePage();
            item.ImagePath = fileName;
            return item;
        }

    }
}
