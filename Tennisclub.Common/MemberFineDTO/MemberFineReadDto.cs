using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.MemberDTO;

namespace Tennisclub.Common.MemberFineDTO
{
    public class MemberFineReadDto
    {
        public int Id { get; set; }
        public int FineNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime HandoutDate { get; set; }
        public DateTime? PaymentDate { get; set; }

        public MemberReadDto Member { get; set; }
    }
}
