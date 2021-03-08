using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.RoleDTO;

namespace Tennisclub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _service;

        public RolesController(IRoleService service)
        {
            _service = service;
        }

        //GET api/roles
        [HttpGet]
        public ActionResult<IEnumerable<RoleReadDto>> GetAllRoles()
        {
            var roles = _service.GetAllRoles();
            return Ok(roles);
        }

        //GET api/roles/{id}
        [HttpGet("{id}")]
        public ActionResult<RoleReadDto> GetRoleById(int id)
        {
            var role = _service.GetRoleById(id);
            return Ok(role);
        }

        //POST api/roles/new
        [HttpPost("new")]
        public ActionResult<RoleReadDto> AddRole(RoleCreateDto role)
        {
            try
            {
                if (role == null)
                    return BadRequest("Role object is null");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var newRole = _service.AddRole(role);
                return Ok(newRole);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //POST api/roles/{id}
        [HttpPut]
        [Route("{id}")]
        public ActionResult<RoleReadDto> EditRole(int id, [FromBody] RoleUpdateDto role)
        {
            try
            {
                if (id != role.Id)
                    return BadRequest("given ID does not match record id.");

                if(role == null)
                    return BadRequest("Role object is null");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var editedRole = _service.UpdateRole(role);
                return Ok(editedRole);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
