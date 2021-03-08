using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.MemberDTO;
using Tennisclub.Common.MemberRoleDTO;
using Tennisclub.Common.RoleDTO;

namespace Tennisclub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberRolesController : ControllerBase
    {
        private readonly IMemberRoleService _service;

        public MemberRolesController(IMemberRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MemberRoleReadDto>> GetAllMemberRoles()
        {
            var memberRoleItems = _service.GetAllMemberRoles();
            return Ok(memberRoleItems);
        }

        [HttpGet]
        [Route("rolesofmember/{id}")]
        public ActionResult<IEnumerable<MemberRoleReadDto>> GetAllRolesOfMember(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Given Id is not valid");

                var rolesOfMemberItems = _service.GetRolesByMemberId(id);
                return Ok(rolesOfMemberItems);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("memberswithrole")]
        public ActionResult<IEnumerable<MemberRoleReadDto>> GetAllMembersOfRole([FromQuery] List<byte> ids)
        {
            var MembersWithRoleItems = _service.GetMembersByRoleId(ids);
            return Ok(MembersWithRoleItems);
        }

        [HttpPost("assign")]
        public ActionResult<MemberRoleReadDto> AssignRole(MemberRoleCreateDto memberRole)
        {
            try
            {
                if (memberRole == null)
                    return BadRequest("MemberRole object is null");

                var AssignedRole = _service.AssignMemberRole(memberRole);
                return Ok(AssignedRole);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("remove/{id}")]
        public ActionResult UpdateMember(MemberRoleUpdateDto memberRole)
        {
            try
            {
                if (memberRole == null)
                    return BadRequest("MemberRole object is null");

                _service.RemoveRole(memberRole);
                return Ok("Role is successfully Removed");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
