using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ey2020UserManager.API.Configuration;
using ey2020UserManager.API.Model;
using ey2020UserManager.Infrustructure.UserAuthService;
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
		private readonly IUserAuthService _userAuthService;
		private readonly IMapper _mapper;

		public UsersController(IUserService userService, IUserAuthService userAuthService, IMapper mapper)
		{
			_userService = userService;
			_userAuthService = userAuthService;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<PaginationDto<UserDto>> GetAllUsers(int page = 0, int size = 10)
		{
			var (items, total) = _userService.GetAllUser(page, size);

			var response = new PaginationDto<UserDto>()
			{
				Page = page + 1,
				Size = size,
				Total = total,
				Data = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(items)
			};

			return Ok(response);
		}

		[HttpGet]
		[Route("{userId}")]
		public ActionResult<UserDetailsDto> GetUserDetails(int userId)
		{
			var user = _userService.GetUserById(userId);

			if (user == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<User, UserDetailsDto>(user));
		}

		[HttpPost]
		public async Task<ActionResult<int>> CreateNewUser([FromBody] UserEntityDto item)
		{
			var user = _mapper.Map<UserEntityDto, User>(item);
			var userId = await _userService.CreateUserAsync(user);

			return Ok(userId);
		}

		[HttpPut("{userId}")]
		public async Task<ActionResult<int>> UpdateUser(int userId, [FromBody] UserEntityDto item)
		{
			var user = _mapper.Map<UserEntityDto, User>(item);
			user.Id = userId;

			var updatedUserId = await _userService.UpdateUserAsync(user);
			return Ok(updatedUserId);
		}

		[HttpDelete("{userId}")]
		public async Task<IActionResult> DeleteUser(int userId)
		{
			await _userService.DeleteUserAsync(userId);
			return NoContent();
		}

		[HttpPost("{userId}/roles")]
		public async Task<ActionResult> LinkedUnlinkedRoleToUser(int userId, [FromBody] int[] roles)
		{
			await _userAuthService.UpdateUserAuthAsync(userId, roles);

			return Ok();
		}
	}
}
