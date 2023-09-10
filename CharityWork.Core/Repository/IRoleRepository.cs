using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Repository {
	public interface IRoleRepository {

		 void createRole(Role role);
		 Task<IEnumerable<Role>> getRoles();
		 Task<Role> getRoleById(int id);
		 void updateRole(Role role);
		 void deleteRole(int id);
		//walaatest
	}
}
