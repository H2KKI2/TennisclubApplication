using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.GenderDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.Repositories.RepositorieInterfaces
{
    public interface IGenderRepository : IGenericRepository<Gender, GenderReadDto, object, object>
    {
    }
}
