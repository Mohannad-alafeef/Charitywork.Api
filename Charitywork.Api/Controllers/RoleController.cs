﻿using CharityWork.Core.Models;
using CharityWork.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : ControllerBase {
		private readonly IRoleService _roleService;

		public RoleController(IRoleService roleService) {
			_roleService = roleService;
		}
	

		[HttpPost]
        [Route("CreateRole")]
        public void createRole(Role role) {
			_roleService.createRole(role);
		}

		[HttpGet]
        [Route("GetAllRoles")]
        public Task<IEnumerable<Role>> getRoles() {
			return _roleService.getRoles();
		}
		[HttpGet]
        [Route("GetRoleById/{id}")]
        public Task<Role> getRoleById(int id) {
			return _roleService.getRoleById(id);
		}
		[HttpPost]
        [Route("UpdateRole")]
        public void updateRole(Role role) {
			_roleService.updateRole(role);
		}
		[HttpDelete]
        [Route("DeleteRole/{id}")]
        public void deleteRole(int id) {
			_roleService.deleteRole(id);
		}

	}
}
