using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialPageController : ControllerBase
    {
        private readonly ITestimonialPageService _testimonialPageService;
         public TestimonialPageController(ITestimonialPageService testimonialPageService)
         {
            _testimonialPageService = testimonialPageService;
         }
        [HttpPost]
        public void createTestimonialPage(TestimonialPage testimonialPage)
        {
            _testimonialPageService.createTestimonialPage(testimonialPage);
        }
        [HttpGet("{id}")]
        public IActionResult getTestimonialpage(int id)
        {
            var testimonial = _testimonialPageService.getTestimonialpage(id);
            if (testimonial == null) {
                return NotFound();
            }
            else
                return Ok(testimonial); 
        }
        [HttpPut("Update")]
        public void updateAboutTestimonialPage(TestimonialPage testimonialPage)
        {
            _testimonialPageService.updateTestimonialPage(testimonialPage);
        }
        [HttpDelete("{id}")]
        public void deleteTestimonialPage(int id)
        {
            _testimonialPageService.deleteTestimonialPage(id);
        }
        [Route("uploadImage")]
        [HttpPost]
        public TestimonialPage UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() +
            "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            TestimonialPage item = new TestimonialPage();
            item.ImagePath = fileName;
            return item;
        }
    }
}
