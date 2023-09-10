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

		public void createRole(Role role) {
			_roleRepository.createRole(role);
		}

		public void deleteRole(int id) {
			_roleRepository.deleteRole(id);
		}

		public Task<Role> getRoleById(int id) {
			return _roleRepository.getRoleById(id);
		}

		public Task<IEnumerable<Role>> getRoles() {
			return _roleRepository.getRoles();
		}

		public void updateRole(Role role) {
			_roleRepository.updateRole(role);
		}
	}
}
