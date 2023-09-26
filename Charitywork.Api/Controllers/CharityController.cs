using CharityWork.Core.Models;
using CharityWork.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharityController : ControllerBase
    {
        private readonly ICharityService _charityService;

        public CharityController(ICharityService charityService)
        {
            _charityService = charityService;
        }

        [Route("uploadImage")]
        [HttpPost]
        public Charity UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\USER\\Desktop\\training\\angular\\New folder\\Charitywork\\src\\assets\\Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Charity item = new Charity();
            item.ImagePath = fileName;
            return item;
        }
        [HttpGet("getAll")]
        public Task<IEnumerable<Charity>> allstatusCharity()
        {
            return _charityService.allstatusCharity();
        }
        [HttpPost]
        [Route("create")]
        public Task<int> createCharity(Charity charity)
        {
            return _charityService.createCharity(charity);
        }
        [HttpPut("Update")]
        public void updateCharity(Charity charity)
        {
            _charityService.updateCharity(charity);
        }
        [HttpDelete("{id}")]
        public void deleteCharity(int id)
        {
            _charityService.deleteCharity(id);
        }
        [HttpGet]
        public Task<IEnumerable<Charity>> allCharity()
        {
            return _charityService.allCharity();
        }
        [HttpGet("getByid/{id}")]
        public IActionResult getCharity(int id)
        {
            var charity = _charityService.getCharity(id);
            if (charity == null)
                return NotFound();
            else
                return Ok(charity);
           
        }
        [HttpGet("getByname/{name}")]
        public Task<IEnumerable<Charity>> SearchByName(string name)
        {
            return _charityService.SearchByName(name);
        }
        [HttpPost("getByDate")]
        public Task<IEnumerable<Charity>> SearchByDate(DateSearch dateSearch)
        {
            return _charityService.SearchByDate(dateSearch);
        }

    }
}
