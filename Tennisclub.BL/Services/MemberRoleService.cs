using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.MemberRoleDTO;
using Tennisclub.Common.RoleDTO;
using Tennisclub.DAL.Models;
using Tennisclub.DAL.Repositories;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.BL.Services
{
    public class MemberRoleService : IMemberRoleService
    {
        private readonly IMemberRoleRepository _repository;

        public MemberRoleService(IMemberRoleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<MemberRoleReadDto> GetAllMemberRoles()
        {
            return _repository.GetAll();
        }

        public MemberRoleReadDto GetMemberRoleById(int id)
        {
            return _repository.GetById(id);
        }
        public IEnumerable<MemberRoleReadDto> GetRolesByMemberId(int memberId)
        {
            return _repository.GetRolesByMemberId(memberId);
        }

        public IEnumerable<MemberRoleReadDto> GetMembersByRoleId(List<byte> ids)
        {
            return _repository.GetMembersOfRole(ids);
        }

        public MemberRoleReadDto AssignMemberRole(MemberRoleCreateDto memberRole)
        {
            ValidationCheck(memberRole.StartDate, memberRole.EndDate);
            MemberRoleCheck(mr => mr.MemberId == memberRole.MemberId && mr.RoleId == memberRole.RoleId && mr.StartDate == memberRole.StartDate && mr.EndDate == memberRole.EndDate);
            return _repository.Add(memberRole);
        }

        public void RemoveRole(MemberRoleUpdateDto memberRole)
        {
            ValidationCheck(memberRole.StartDate, memberRole.EndDate);
            MemberRoleCheck(mr => mr.Id != memberRole.Id && mr.MemberId == memberRole.MemberId && mr.RoleId == memberRole.RoleId && mr.StartDate == memberRole.StartDate && mr.EndDate == memberRole.EndDate);
            _repository.DeleteRole(memberRole);
        }

        private void ValidationCheck(DateTime startDate, DateTime? endDate)
        {
            if (endDate != null)
            {
                if (startDate > endDate)
                    throw new ArgumentException("End date can't come before start date");
            }
        }

        private void MemberRoleCheck(Func<MemberRole, bool> filter)
        {
            IEnumerable<MemberRoleReadDto> listMemberRoles = _repository.GetAllFiltered(filter);
            if (listMemberRoles.Count() != 0)
                throw new ArgumentException("Member role name is not unique");
        }
    }
}
