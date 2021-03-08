using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub.Common.RoleDTO;
using Tennisclub.DAL.Data;
using Tennisclub.DAL.Models;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.DAL.Repositories
{
    class RoleRepository : GenericRepository<Role, RoleReadDto, RoleCreateDto, RoleUpdateDto>, IRoleRepository
    {
        public RoleRepository(TennisclubContext context, IMapper mapper)
            : base(context, mapper)
        { }

        public override IEnumerable<RoleReadDto> GetAll()
        {
            return _mapper.Map<IEnumerable<RoleReadDto>>(_GetAll().OrderBy(s => s.Id));
        }
    }
}
