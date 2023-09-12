using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Services
{
    public interface ITestimonialService
    {

        public Task<IEnumerable<Testimonial>> GetAllTestimonial();
        public void CreateTestimonial(Testimonial testimonial);
        public void DeleteTestimonial(int id);
        public Testimonial GetTestimonialById(int id);
        public void UpdateTestimonial(Testimonial testimonial);
    }
}
