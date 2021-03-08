using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub.Common.MemberFineDTO;
using Tennisclub.DAL.Data;
using Tennisclub.DAL.Models;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.DAL.Repositories
{
    public class MemberFineRepository : GenericRepository<MemberFine, MemberFineReadDto, MemberFineCreateDto, MemberFineUpdateDto>, IMemberFineRepository
    {
        public MemberFineRepository(TennisclubContext context, IMapper mapper)
            : base(context, mapper)
        { }

        public override IEnumerable<MemberFineReadDto> GetAll()
        {
            return _mapper.Map<IEnumerable<MemberFineReadDto>>(_dbSet.AsNoTracking().Include(mf => mf.Member));
        }
        public IEnumerable<MemberFineReadDto> GetFinesByMemberId(int memberId)
        {
            return _mapper.Map<IEnumerable<MemberFineReadDto>>(_dbSet.AsNoTracking().Include(mf => mf.Member).Where(mr => mr.MemberId == memberId));
        }

        public override List<MemberFine> _GetAll()
        {
            return _dbSet.AsNoTracking().Include(mf => mf.Member).ToList();
        }

        public override MemberFineReadDto Update(MemberFineUpdateDto item)
        {
            int id = item.Id;
            MemberFine updatedFine = _dbSet.Find(id);

            if (updatedFine == null)
                throw new NullReferenceException("The fine of a member with this id is not found");

            updatedFine.PaymentDate = item.PaymentDate;
            _context.Entry(updatedFine).Property(mf => mf.PaymentDate).IsModified = true;
            Save();

            return _mapper.Map<MemberFineReadDto>(updatedFine);
        }
    }
}
