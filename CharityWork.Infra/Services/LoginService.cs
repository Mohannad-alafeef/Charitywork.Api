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

		public Task<IEnumerable<UserLogin>> AllLogin() {
			return _loginRepository.AllLogin();
		}

		public void CreateLogin(UserLogin login) {
			_loginRepository.CreateLogin(login);
		}

		public void DeleteLogin(int id) {
			_loginRepository.DeleteLogin(id);
		}

		public Task<UserLogin> GetLogin(int id) {
			return _loginRepository.GetLogin(id);
		}

		public void UpdateLogin(UserLogin login) {
			_loginRepository.UpdateLogin(login);
		}
	}
}
