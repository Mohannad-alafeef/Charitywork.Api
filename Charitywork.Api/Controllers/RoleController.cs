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
		public void CreateRole(Role role) {
			_roleService.CreateRole(role);
		}

		[HttpGet]

        [Route("GetAllRoles")]
        public Task<IEnumerable<Role>> GetRoles() {
			return _roleService.GetRoles();
		}
		[HttpGet]
        [Route("GetRoleById/{id}")]

        public Task<Role> GetRoleById(int id) {

			return _roleService.GetRoleById(id);
		}
		[HttpPost]
        [Route("UpdateRole")]
        public void UpdateRole(Role role) {
			_roleService.UpdateRole(role);
		}
		[HttpDelete]
        [Route("DeleteRole/{id}")]
        public void DeleteRole(int id) {
			_roleService.DeleteRole(id);
		}

	}
}
