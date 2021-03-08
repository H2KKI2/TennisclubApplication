using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.GenderDTO;
using Tennisclub.DAL.Data;
using Tennisclub.DAL.Models;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.DAL.Repositories
{
    public class GenderRepository : GenericRepository<Gender, GenderReadDto, object, object>, IGenderRepository
    {
        public GenderRepository(TennisclubContext context, IMapper mapper)
            : base(context, mapper)
        { }

        public override IEnumerable<GenderReadDto> GetAll()
        {
            return _mapper.Map<IEnumerable<GenderReadDto>>(_context.Genders.FromSqlRaw("EXECUTE dbo.sp_GetAllGenders "));
        }

    }
}

