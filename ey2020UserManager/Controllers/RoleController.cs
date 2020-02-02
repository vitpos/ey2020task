using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ey2020UserManager.Infrustructure.RoleService;
using ey2020UserManager.Persistence.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ey2020UserManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Role>> GetRoles()
        {
            var roles = _roleService.GetAllRoles() ?? Enumerable.Empty<Role>();

            return Ok(roles);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Role>> GetRoleById(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);

            if(role == null)
            {
                return BadRequest($"Entity with {id} not found.");
            }

            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Role entity)
        {
            await _roleService.CreateRoleAsync(entity);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Role entity)
        {
            var role = new Role()
            {
                Id = entity.Id,
                RoleName = entity.RoleName,
                IsActive = entity.IsActive
            };

            await _roleService.UpdateRoleAsync(role);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleService.DeleteRoleAsync(id);
            return Ok();
        }
    }
}
