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
    public class TestimonialPageService:ITestimonialPageService
    {
        private readonly ITestimonialPageRepository _testimonialPageRepository;
        public TestimonialPageService(ITestimonialPageRepository testimonialPageRepository)
        {
            _testimonialPageRepository = testimonialPageRepository;
        }
        public void createTestimonialPage(TestimonialPage testimonialPage)
        {
            _testimonialPageRepository.createTestimonialPage(testimonialPage);
        }
        public TestimonialPage getTestimonialpage(int id)
        {
            return _testimonialPageRepository.getTestimonialpage(id);
        }
        public void updateTestimonialPage(TestimonialPage testimonialPage)
        {
            _testimonialPageRepository.updateTestimonialPage(testimonialPage);
        }
        public void deleteTestimonialPage(int id)
        {
            _testimonialPageRepository.deleteTestimonialPage(id);
        }
    }
}
