﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub.Common.MemberDTO
{
    public class MemberUpdateDto
    {
        public int Id { get; set; }
        public string FederationNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public byte GenderId { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Addition { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string PhoneNr { get; set; }
        public bool IsDeleted { get; set; }
    }
}
