using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Services {
	public interface ILoginService {
		void CreateLogin(UserLogin login);
		void UpdateLogin(UserLogin login);
		void DeleteLogin(int id);
		Task<IEnumerable<UserLogin>> AllLogin();
		Task<UserLogin> GetLogin(int id);
		Task<string?> Auth(UserLogin userLogin);
	}
}
