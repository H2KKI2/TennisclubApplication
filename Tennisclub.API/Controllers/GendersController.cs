using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.GenderDTO;

namespace Tennisclub.API.Controllers
{
    [Route("api/genders")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IGenderService _service;

        public GendersController(IGenderService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GenderReadDto>> GetAllMemberRoles()
        {
            var genderItems = _service.GetAllGenders();
            return Ok(genderItems);
        }
    }
}
