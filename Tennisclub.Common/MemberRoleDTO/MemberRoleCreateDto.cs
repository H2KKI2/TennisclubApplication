using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub.Common.MemberRoleDTO
{
    public class MemberRoleCreateDto
    {
        public int MemberId { get; set; }
        public byte RoleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
