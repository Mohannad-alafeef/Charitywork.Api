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
    public class ContactPageService:IContactPageService
    {

        private readonly IContactPageRepository _contactPageRepository;
        public ContactPageService(IContactPageRepository contactPageRepository)
        {
            _contactPageRepository = contactPageRepository;
        }

        public void createContactPage(ContactUsPage contactUsPage)
        {
            _contactPageRepository.createContactPage(contactUsPage);
        }
        public ContactUsPage getContact(int id)
        {
            return _contactPageRepository.getContact(id);
        }
        public void updateContactPage(ContactUsPage contactUsPage)
        {
            _contactPageRepository.updateContactPage(contactUsPage);
        }
        public void deleteContactPage(int id)
        {
            _contactPageRepository.deleteContactPage(id);
        }
    }
}
