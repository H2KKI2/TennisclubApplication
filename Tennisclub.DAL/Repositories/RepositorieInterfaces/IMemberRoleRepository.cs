using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.MemberRoleDTO;
using Tennisclub.Common.RoleDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.Repositories.RepositorieInterfaces
{
    public interface IMemberRoleRepository : IGenericRepository<MemberRole, MemberRoleReadDto, MemberRoleCreateDto, MemberRoleUpdateDto>
    {
        IEnumerable<MemberRoleReadDto> GetRolesByMemberId(int memberId);
        IEnumerable<MemberRoleReadDto> GetMembersOfRole(List<byte> ids);
        void DeleteRole(MemberRoleUpdateDto memberRole);
    }
}
