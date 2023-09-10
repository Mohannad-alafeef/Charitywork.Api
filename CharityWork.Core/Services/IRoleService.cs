using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Services {
	public interface IRoleService {
		void CreateRole(Role role);
		Task<IEnumerable<Role>> GetRoles();
		Task<Role> GetRoleById(int id);
		void UpdateRole(Role role);
		void DeleteRole(int id);
	}
}
