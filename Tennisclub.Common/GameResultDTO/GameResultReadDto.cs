using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.GameDTO;

namespace Tennisclub.Common.GameResultDTO
{
    public class GameResultReadDto
    {
        public int Id { get; set; }
        public byte SetNr { get; set; }
        public byte ScoreTeamMember { get; set; }
        public byte ScoreOpponent { get; set; }

        public GameReadDto Game { get; set; }
    }
}
