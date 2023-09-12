using CharityWork.Core.Models;
using CharityWork.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {

        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        [Route("GetAllTestimonial")]
        public Task<IEnumerable<Testimonial>> GetAllTestimonial()
        {
            return _testimonialService.GetAllTestimonial();
        }
        [HttpPost]
        [Route("CreateTestimonial")]
        public void CreateTestimonial(Testimonial testimonial)
        {
            _testimonialService.CreateTestimonial(testimonial);
        }

        [HttpDelete]
        [Route("DeleteTestimonial/{id}")]
        public void DeleteTestimonial(int id)
        {
            _testimonialService.DeleteTestimonial(id);
        }

        [HttpGet]
        [Route("GetTestimonialById/{id}")]
        public Testimonial GetTestimonialById(int id)
        {
            return _testimonialService.GetTestimonialById(id);
        }

        [HttpPost]
        [Route("UpdateTestimonial")]
        public void UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialService.UpdateTestimonial(testimonial);
        }

    }
}
