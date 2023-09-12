using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Services
{
    public interface IAboutPageService
    {
        void createAboutPage(AboutUsPage aboutUsPage);
        AboutUsPage getAbout(int id);
        void updateAboutPage(AboutUsPage aboutUsPage);
        void deleteAboutPage(int id);
    }
}
