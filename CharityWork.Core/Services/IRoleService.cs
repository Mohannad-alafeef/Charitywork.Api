using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Services {
	public interface IRoleService {
		void createRole(Role role);
		Task<IEnumerable<Role>> getRoles();
		Task<Role> getRoleById(int id);
		void updateRole(Role role);
		void deleteRole(int id);
	}
}
