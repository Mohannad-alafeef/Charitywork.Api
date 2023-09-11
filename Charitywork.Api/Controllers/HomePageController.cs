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
        public HomePage getHome(int id)
        {
            return _homePageServices.getHome(id);
        }
        [HttpPut("Update")]
        public void updateHomePage(HomePage homePage)
        {
            _homePageServices.updateHomePage(homePage);
        }

    }
}
