using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.MemberFineDTO;

namespace Tennisclub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberFinesController : ControllerBase
    {
        private readonly IMemberFineService _service;

        public MemberFinesController(IMemberFineService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MemberFineReadDto>> GetAllMemberFines()
        {
            var memberFineItems = _service.GetAllFines();
            return Ok(memberFineItems);
        }

        [HttpGet("filter")]
        public IEnumerable<MemberFineReadDto> GetAllMembersFiltered([FromQuery] DateTime? handoutDate, [FromQuery] DateTime? paymentDate)
        {
            return _service.GetAllFinesFiltered(handoutDate, paymentDate);
        }


        [HttpGet]
        [Route("finesofmember/{id}")]
        public ActionResult<IEnumerable<MemberFineReadDto>> GetAllFinesOfMember(int id)
        {
            try
            {
                if(id <= 0)
                    return BadRequest("Given Id is not valid");

                var finesOfMemberItems = _service.GetAllFinesByMemberId(id);
                return Ok(finesOfMemberItems);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("new")]
        public ActionResult<MemberFineReadDto> AddFine(MemberFineCreateDto memberFine)
        {
            try
            {
                if (memberFine == null)
                    return BadRequest("MemberFine object is null");

                var addedFine = _service.AddMemberFine(memberFine);
                return Ok(addedFine);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult CompleteFine(MemberFineUpdateDto memberFine)
        {
            try
            {
                if (memberFine == null)
                    return BadRequest("MemberFine object is null");

                _service.CompleteMemberFine(memberFine);
                return Ok("Fine is successfully Completed");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
