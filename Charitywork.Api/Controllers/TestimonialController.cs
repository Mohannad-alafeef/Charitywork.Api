using CharityWork.Core.Models;
using CharityWork.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase {

		private readonly ITestimonialService _testimonialService;

		public TestimonialController(ITestimonialService testimonialService) {
			_testimonialService = testimonialService;
		}

		[HttpGet]
		
		public Task<IEnumerable<Testimonial>> GetAllTestimonial() {
			return _testimonialService.GetAllTestimonial();
		}
		[HttpPost]
		
		public void CreateTestimonial(Testimonial testimonial) {
			_testimonialService.CreateTestimonial(testimonial);
		}

		[HttpDelete("{id}")]
	
		public void DeleteTestimonial(int id) {
			_testimonialService.DeleteTestimonial(id);
		}

		[HttpGet("{id}")]
	
		public IActionResult GetTestimonialById(int id) {
			var testimonial = _testimonialService.GetTestimonialById(id);
			if (testimonial == null) {
				return NotFound();
			}
			else
				return Ok(testimonial);
		}

		[HttpPut]
		public void UpdateTestimonial(Testimonial testimonial) {
			_testimonialService.UpdateTestimonial(testimonial);
		}

	}
}
