using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Services {
	public interface IContactService {
		void CreateContact(Contact contact);
		Task<IEnumerable<Contact>> GetAll();
		void DeleteContact(int id);
		void ChangeStatus(Contact contact);
	}
}
