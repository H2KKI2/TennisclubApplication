using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.MemberDTO;


namespace Tennisclub.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _service;

        public MembersController(IMemberService service)
        {
            _service = service;
        }

        //GET api/members
        [HttpGet]
        public ActionResult<IEnumerable<MemberReadDto>> GetAllMembers()
        {
            var memberItems = _service.GetAllMembers();
            return Ok(memberItems);
        }

        //GET api/members/{id}
        [HttpGet("{id}")]
        public ActionResult<MemberReadDto> GetMemberById(int id)
        {
            var memberItem = _service.GetMemberById(id);
            return Ok(memberItem);
        }

        //GET api/members/filtered
        [HttpGet("filter")]
        public IEnumerable<MemberReadDto> GetAllMembersFiltered([FromQuery] string federationNr, [FromQuery] string firstName, [FromQuery] string lastName,
                                                         [FromQuery] string city, [FromQuery] string zipcode)
        {
            return _service.GetAllMembersFiltered(federationNr, firstName, lastName, city, zipcode);
        }

        [HttpPost("new")]
        public ActionResult<MemberReadDto> AddMember(MemberCreateDto member)
        {
            try
            {
                if (member == null)
                    return BadRequest("Member object is null");

                var newMember = _service.AddMember(member);
                return Ok(newMember);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateMember(MemberUpdateDto member)
        {
            try
            {
                if (member == null)
                    return BadRequest("Member object is null");

                _service.UpdateMember(member);
                return Ok("Member is successfully updated");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult RemoveMember(int id)
        {
            _service.DeleteMember(id);
            return Ok("Member is successfully deleted");
        }

        [HttpPut]
        [Route("restore/{id}")]
        public ActionResult RestoreMember(int id)
        {
            _service.RestoreMember(id);
            return Ok("Member is successfully restored");
        }
    }
}
