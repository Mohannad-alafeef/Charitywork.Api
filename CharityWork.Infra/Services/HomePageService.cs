using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using CharityWork.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Services
{
    public class HomePageService : IHomePageService
    {


        private readonly IHomePageRepository _homePageRepository;
        public HomePageService(IHomePageRepository homePageRepository )
        {
            _homePageRepository = homePageRepository;
        }

        public void createHomePage(HomePage homePage)
        {
            _homePageRepository.createHomePage(homePage);
        }

        public void deleteHomePage(int id)
        {
            _homePageRepository.deleteHomePage(id);
        }

        public HomePage getHome(int id)
        {
            return  _homePageRepository.getHome(id);
        }


        public void updateHomePage(HomePage homePage)
        { 
            _homePageRepository.updateHomePage(homePage);
        }
    }
}
