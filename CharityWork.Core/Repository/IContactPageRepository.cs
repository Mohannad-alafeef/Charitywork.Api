using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Repository
{
    public interface IContactPageRepository
    {
        void createContactPage(ContactUsPage contactUsPage);
        ContactUsPage getContact(int id);
        void updateContactPage(ContactUsPage contactUsPage);
        void deleteContactPage(int id);
    }
}
