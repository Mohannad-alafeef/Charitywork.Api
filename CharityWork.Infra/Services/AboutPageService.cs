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
    public class AboutPageService :IAboutPageService
    {
        private readonly IAboutPageRepository _aboutPageRepository;
        public AboutPageService(IAboutPageRepository aboutPageRepository)
        {
            _aboutPageRepository = aboutPageRepository;
        }

        public void createAboutPage(AboutUsPage aboutUsPage)
        {
            _aboutPageRepository.createAboutPage(aboutUsPage);
        }
        public AboutUsPage getAbout(int id)
        {
            return _aboutPageRepository.getAbout(id);
        }
        public void updateAboutPage(AboutUsPage aboutUsPage)
        {
            _aboutPageRepository.updateAboutPage(aboutUsPage);
        }
        public void deleteAboutPage(int id)
        {
            _aboutPageRepository.deleteAboutPage(id);
        }
    }
}
