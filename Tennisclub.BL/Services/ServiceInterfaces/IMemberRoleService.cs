using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.MemberRoleDTO;
using Tennisclub.Common.RoleDTO;

namespace Tennisclub.BL.Services.ServiceInterfaces
{
    public interface IMemberRoleService
    {
        IEnumerable<MemberRoleReadDto> GetAllMemberRoles();
        MemberRoleReadDto GetMemberRoleById(int id);
        MemberRoleReadDto AssignMemberRole(MemberRoleCreateDto item);
        IEnumerable<MemberRoleReadDto> GetRolesByMemberId(int memberId);
        IEnumerable<MemberRoleReadDto> GetMembersByRoleId(List<byte> ids);
        void RemoveRole(MemberRoleUpdateDto memberRole);
    }
}
