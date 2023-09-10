using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Services {
	public class LoginService : ILoginService {

		private readonly ILoginRepository _loginRepository;

		public LoginService(ILoginRepository loginRepository) {
			_loginRepository = loginRepository;
		}

		public Task<IEnumerable<UserLogin>> allLogin() {
			return _loginRepository.allLogin();
		}

		public void createLogin(UserLogin login) {
			_loginRepository.createLogin(login);
		}

		public void deleteLogin(int id) {
			_loginRepository.deleteLogin(id);
		}

		public Task<UserLogin> getLogin(int id) {
			return _loginRepository.getLogin(id);
		}

		public void updateLogin(UserLogin login) {
			_loginRepository.updateLogin(login);
		}
	}
}
