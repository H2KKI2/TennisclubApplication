using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.MemberDTO;
using Tennisclub.Common.RoleDTO;

namespace Tennisclub.Common.MemberRoleDTO
{
    public class MemberRoleReadDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public MemberReadDto Member { get; set; }
        public RoleReadDto Role { get; set; }
    }
}
