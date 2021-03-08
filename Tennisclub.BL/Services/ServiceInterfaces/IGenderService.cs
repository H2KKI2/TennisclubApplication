using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.GenderDTO;

namespace Tennisclub.BL.Services.ServiceInterfaces
{
    public interface IGenderService
    {
        IEnumerable<GenderReadDto> GetAllGenders();
    }
}
