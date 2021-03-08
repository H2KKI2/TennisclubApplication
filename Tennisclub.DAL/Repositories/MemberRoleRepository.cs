using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub.Common.MemberRoleDTO;
using Tennisclub.Common.RoleDTO;
using Tennisclub.DAL.Data;
using Tennisclub.DAL.Models;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.DAL.Repositories
{
    public class MemberRoleRepository : GenericRepository<MemberRole, MemberRoleReadDto, MemberRoleCreateDto, MemberRoleUpdateDto>, IMemberRoleRepository
    {
        public MemberRoleRepository(TennisclubContext context, IMapper mapper)
            :base(context, mapper)
        { }

        public void DeleteRole(MemberRoleUpdateDto memberRole)
        {
            Update(memberRole);
        }

        public IEnumerable<MemberRoleReadDto> GetMembersOfRole(List<byte> ids)
        {
            return _mapper.Map<IEnumerable<MemberRoleReadDto>>(_dbSet.AsNoTracking().Include(mr => mr.Role).Include(mr => mr.Member).ThenInclude(m => m.Gender).Where(mr => ids.Contains(mr.RoleId)));
        }

        public IEnumerable<MemberRoleReadDto> GetRolesByMemberId(int memberId)
        {
            return _mapper.Map<IEnumerable<MemberRoleReadDto>>(_dbSet.AsNoTracking().Include(mr => mr.Role).Where(mr => mr.MemberId == memberId));
        }


    }
}
