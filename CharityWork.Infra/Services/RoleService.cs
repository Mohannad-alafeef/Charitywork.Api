using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Services {
	public class RoleService : IRoleService {
		private readonly IRoleRepository _roleRepository;

		public RoleService(IRoleRepository roleRepository) {
			_roleRepository = roleRepository;
		}

		public void CreateRole(Role role) {
			_roleRepository.CreateRole(role);
		}

		public void DeleteRole(int id) {
			_roleRepository.DeleteRole(id);
		}

		public Task<Role> GetRoleById(int id) {
			return _roleRepository.GetRoleById(id);
		}

		public Task<IEnumerable<Role>> GetRoles() {
			return _roleRepository.GetRoles();
		}

		public void UpdateRole(Role role) {
			_roleRepository.UpdateRole(role);
		}
	}
}
