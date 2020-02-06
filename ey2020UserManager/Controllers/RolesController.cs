using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ey2020UserManager.API.Configuration;
using ey2020UserManager.API.Model;
using ey2020UserManager.Infrustructure.RoleService;
using ey2020UserManager.Persistence.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ey2020UserManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion(ApiConfiguration.ApiVersion)]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoleDto>> GetRoles()
        {
            var roles = _roleService.GetAllRoles();

            return Ok(_mapper.Map<IEnumerable<Role>, IEnumerable<RoleDto>>(roles));
        }

        [HttpGet]
        [Route("{roleId}")]
        public async Task<ActionResult<RoleDto>> GetRoleById(int roleId)
        {
            var role = await _roleService.GetRoleByIdAsync(roleId);

            if(role == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Role, RoleDto>(role));
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateNewRole([FromBody] RoleEntityDto item)
        {
            var roleId = await _roleService.CreateRoleAsync(_mapper.Map<RoleEntityDto, Role>(item));
            return Ok(roleId);
        }

        [HttpPut("{roleId}")]
        public async Task<ActionResult<int>> Put(int roleId, [FromBody] RoleEntityDto item)
        {
            var role = _mapper.Map<RoleEntityDto, Role>(item);
            role.Id = roleId;

            return Ok(await _roleService.UpdateRoleAsync(role));
        }

        [HttpDelete("{roleId}")]
        public async Task<IActionResult> Delete(int roleId)
        {
            await _roleService.DeleteRoleAsync(roleId);
            return NoContent();
        }
    }
}
