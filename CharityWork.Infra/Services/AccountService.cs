using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Services {
	public class AccountService : IAccountService {
		private readonly IAccountRepository _accountRepository;

		public AccountService(IAccountRepository accountRepository) {
			_accountRepository = accountRepository;
		}

		public void CreateAccount(UserAccount userAccount) {
			_accountRepository.CreateAccount(userAccount);
		}

		public void DeleteAccount(int id) {
			_accountRepository.DeleteAccount(id);
		}

		public Task<IEnumerable<UserAccount>> GetAll() {
			return _accountRepository.GetAll();
		}

		public Task<UserAccount> GetById(int id) {
			return _accountRepository.GetById(id);
		}

		public void UpdateAccount(UserAccount userAccount) {
			_accountRepository.UpdateAccount(userAccount);
		}
	}
}
