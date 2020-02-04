using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ey2020UserManager.API.Configuration;
using ey2020UserManager.API.Model;
using ey2020UserManager.Infrustructure.UserService;
using ey2020UserManager.Persistence.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ey2020UserManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion(ApiConfiguration.ApiVersion)]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<UserDto> GetAllUsers()
        {
            var users = _userService.GetAllUser();
            return Ok(_mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users));
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<UserDto>> GetUserDetails(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<User, UserDto>(user));
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateNewUser([FromBody] UserDto item)
        {
            var user = _mapper.Map<UserDto, User>(item);

            var userId = await _userService.CreateUserAsync(user);

            return Ok(userId);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<int>> Put(int userId, [FromBody] UserDto item)
        {
            var user = _mapper.Map<UserDto, User>(item);
            user.Id = userId;

            return Ok(await _userService.UpdateUserAsync(user));
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            await _userService.DeleteUserAsync(userId);
            return NoContent();
        }
    }
}
