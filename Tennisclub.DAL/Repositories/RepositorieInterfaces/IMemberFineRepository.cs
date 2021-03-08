using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.MemberFineDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.Repositories.RepositorieInterfaces
{
    public interface IMemberFineRepository : IGenericRepository<MemberFine, MemberFineReadDto, MemberFineCreateDto, MemberFineUpdateDto>
    {
        IEnumerable<MemberFineReadDto> GetFinesByMemberId(int memberId);
    }
}
