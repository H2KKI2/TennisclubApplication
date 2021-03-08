using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.RoleDTO;

namespace Tennisclub.BL.Services.ServiceInterfaces
{
    public interface IRoleService
    {
        IEnumerable<RoleReadDto> GetAllRoles();
        RoleReadDto GetRoleById(int id);
        RoleReadDto AddRole(RoleCreateDto role);
        RoleReadDto UpdateRole(RoleUpdateDto role);
    }
}
