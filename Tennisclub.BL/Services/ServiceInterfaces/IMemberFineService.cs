using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.MemberFineDTO;

namespace Tennisclub.BL.Services.ServiceInterfaces
{
    public interface IMemberFineService
    {
        IEnumerable<MemberFineReadDto> GetAllFines();
        IEnumerable<MemberFineReadDto> GetAllFinesFiltered(DateTime? handoutDate, DateTime? paymentDate);
        IEnumerable<MemberFineReadDto> GetAllFinesByMemberId(int id);
        MemberFineReadDto AddMemberFine(MemberFineCreateDto memberFine);
        void CompleteMemberFine(MemberFineUpdateDto memberFine);

    }
}
