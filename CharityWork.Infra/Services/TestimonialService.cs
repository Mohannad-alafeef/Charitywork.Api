using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Services
{
    public class TestimonialService :ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;
        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        public Task<IEnumerable<Testimonial>> GetAllTestimonial() { return _testimonialRepository.GetAllTestimonial(); }
        public void CreateTestimonial(Testimonial testimonial) { _testimonialRepository.CreateTestimonial(testimonial); }
        public void DeleteTestimonial(int id) { _testimonialRepository.DeleteTestimonial(id); }
        public Testimonial GetTestimonialById(int id) { return _testimonialRepository.GetTestimonialById(id); }
        public void UpdateTestimonial(Testimonial testimonial) { _testimonialRepository.UpdateTestimonial(testimonial); }
     
    }
}
