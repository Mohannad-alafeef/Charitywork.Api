using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Services {
	public interface ILoginService {
		void createLogin(UserLogin login);
		void updateLogin(UserLogin login);
		void deleteLogin(int id);
		Task<IEnumerable<UserLogin>> allLogin();
		Task<UserLogin> getLogin(int id);
	}
}
