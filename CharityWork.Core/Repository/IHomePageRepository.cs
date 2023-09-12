using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Repository
{
    public interface IHomePageRepository
    {
        void createHomePage(HomePage homePage);
        HomePage getHome(int id);
        void updateHomePage(HomePage homePage);
        void deleteHomePage(int id);
    }
}
