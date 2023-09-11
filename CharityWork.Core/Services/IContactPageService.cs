using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Services
{
    public interface IContactPageService
    {
        void createContactPage(ContactUsPage contactUsPage);
        ContactUsPage getContact(int id);
        void updateContactPage(ContactUsPage contactUsPage);
        void deleteContactPage(int id);
    }
}
