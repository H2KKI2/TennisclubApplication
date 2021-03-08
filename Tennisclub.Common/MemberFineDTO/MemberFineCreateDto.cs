using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub.Common.MemberFineDTO
{
    public class MemberFineCreateDto
    {
        public int FineNumber { get; set; }
        public int MemberId { get; set; }
        public decimal Amount { get; set; }
        public DateTime HandoutDate { get; set; }
        public DateTime? PaymentDate { get; set; }

    }
}
