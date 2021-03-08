using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.LeagueDTO;
using Tennisclub.Common.MemberDTO;

namespace Tennisclub.Common.GameDTO
{
    public class GameReadDto
    {
        public int Id { get; set; }
        public string GameNumber { get; set; }
        public DateTime Date { get; set; }

        public MemberReadDto Member { get; set; }
        public LeagueReadDto League { get; set; }
    }
}
