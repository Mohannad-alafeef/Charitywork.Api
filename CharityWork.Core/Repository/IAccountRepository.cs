﻿using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Repository {
	public interface IAccountRepository {

		void CreateAccount(UserAccount userAccount);
		Task<IEnumerable<UserAccount>> GetAll();
		Task<UserAccount> GetById(int id);
		void UpdateAccount(UserAccount userAccount);
		void DeleteAccount(int id);

	}
}
