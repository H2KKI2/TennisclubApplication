using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.MemberDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.Repositories
{
    public interface IMemberRepository : IGenericRepository<Member, MemberReadDto, MemberCreateDto, MemberUpdateDto>
    {
        void DeleteMember(int id);
        void RestoreMember(int id);
        IEnumerable<MemberReadDto> GetAllMembersWithDeletedFiltered(Func<Member, bool> filter);
    }
}
