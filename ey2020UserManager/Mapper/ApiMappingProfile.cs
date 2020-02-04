using AutoMapper;
using ey2020UserManager.API.Model;
using ey2020UserManager.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ey2020UserManager.API.Mapper
{
	public class ApiMappingProfile : Profile
	{
		public ApiMappingProfile()
		{
			CreateMap<User, UserDto>()
				.ForMember(d => d.UserId, o => o.MapFrom(x => x.Id))
				.ForMember(d => d.FirstName, o => o.MapFrom(x => x.FirstName))
				.ForMember(d => d.LastName, o => o.MapFrom(x => x.LastName))
				.ForMember(d => d.Email, o => o.MapFrom(x => x.Email))
				.ForMember(d => d.PhoneNumber, o => o.MapFrom(x => x.PhoneNumber))
				.ForMember(d => d.IsEnabled, o => o.MapFrom(x => x.IsEnabled))
				.ForAllOtherMembers(d => d.Ignore());

			CreateMap<UserDto, User>()
				.ForMember(d => d.FirstName, o => o.MapFrom(x => x.FirstName))
				.ForMember(d => d.LastName, o => o.MapFrom(x => x.LastName))
				.ForMember(d => d.Email, o => o.MapFrom(x => x.Email))
				.ForMember(d => d.PhoneNumber, o => o.MapFrom(x => x.PhoneNumber))
				.ForMember(d => d.IsEnabled, o => o.MapFrom(x => x.IsEnabled))
				.ForAllOtherMembers(d => d.Ignore());

			CreateMap<Role, RoleDto>()
				.ForMember(d => d.RoleId, o => o.MapFrom(x => x.Id))
				.ForMember(d => d.RoleName, o => o.MapFrom(x => x.RoleName))
				.ForMember(d => d.IsEnabled, o => o.MapFrom(x => x.IsEnabled))
				.ForAllOtherMembers(d => d.Ignore());

			CreateMap<RoleDto, Role>()
				.ForMember(d => d.RoleName, o => o.MapFrom(x => x.RoleName))
				.ForMember(d => d.IsEnabled, o => o.MapFrom(x => x.IsEnabled))
				.ForAllOtherMembers(d => d.Ignore());
		}

	}
}
