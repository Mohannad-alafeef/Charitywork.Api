using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Services {
	public class ContactService : IContactService {

		private readonly IContactRepository _contactRepository;

		public ContactService(IContactRepository contactRepository) {
			_contactRepository = contactRepository;
		}

		public void ChangeStatus(Contact contact) {
			_contactRepository.ChangeStatus(contact);
		}

		public void CreateContact(Contact contact) {
			_contactRepository.CreateContact(contact);
		}

		public void DeleteContact(int id) {
			_contactRepository.DeleteContact(id);
		}

		public Task<IEnumerable<Contact>> GetAll() {
			return _contactRepository.GetAll();
		}
	}
}
