using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tennisclub.Common.MemberDTO;
using Tennisclub.DAL.Data;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.Repositories
{
    public class MemberRepository : GenericRepository<Member, MemberReadDto, MemberCreateDto, MemberUpdateDto>, IMemberRepository
    {
        public MemberRepository(TennisclubContext context, IMapper mapper)
            :base(context, mapper)
        { }
        public override IEnumerable<MemberReadDto> GetAll()
        {
            return _mapper.Map<IEnumerable<MemberReadDto>>(_dbSet.AsNoTracking().Include(m => m.Gender).Where(m => m.IsDeleted == false));
        }

        public override IEnumerable<MemberReadDto> GetAllFiltered(Func<Member, bool> filter)
        {
            return _mapper.Map<IEnumerable<MemberReadDto>>(_dbSet.AsNoTracking().Include(m => m.Gender).Where(filter).ToList());
        }

        public void DeleteMember(int id)
        {
            Member removedMember = _dbSet.Find(id);

            if (removedMember == null)
                throw new NullReferenceException("Member with this id is not found");

            removedMember.IsDeleted = true;
            _context.Entry(removedMember).Property(m => m.IsDeleted).IsModified = true;
            Save();
        }

        public void RestoreMember(int id)
        {
            Member restoredMember = _dbSet.Find(id);

            if (restoredMember == null)
                throw new NullReferenceException("Member with this id is not found");

            restoredMember.IsDeleted = false;
            _context.Entry(restoredMember).Property(m => m.IsDeleted).IsModified = true;
            Save();
        }

        public IEnumerable<MemberReadDto> GetAllMembersWithDeletedFiltered(Func<Member, bool> filter)
        {
            return _mapper.Map<IEnumerable<MemberReadDto>>(_dbSet.AsNoTracking().Include(m => m.Gender).Where(filter).ToList());
        }
    }
}
