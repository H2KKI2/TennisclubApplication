using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.RoleDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.Repositories.RepositorieInterfaces
{
    public interface IRoleRepository : IGenericRepository<Role, RoleReadDto, RoleCreateDto, RoleUpdateDto>
    {
    }
}
