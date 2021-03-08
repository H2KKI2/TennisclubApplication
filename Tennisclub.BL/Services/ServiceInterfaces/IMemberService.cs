using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.MemberDTO;

namespace Tennisclub.BL.Services.ServiceInterfaces
{
    public interface IMemberService
    {
        IEnumerable<MemberReadDto> GetAllMembers();
        IEnumerable<MemberReadDto> GetAllMembersFiltered(string federationNr, string firstName, string lastName, string city, string zipcode);
        MemberReadDto GetMemberById(int id);
        MemberReadDto AddMember(MemberCreateDto member);
        void UpdateMember(MemberUpdateDto member);
        void DeleteMember(int id);
        void RestoreMember(int id);
    }
}
