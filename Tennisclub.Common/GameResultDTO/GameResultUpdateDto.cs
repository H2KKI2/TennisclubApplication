﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub.Common.GameResultDTO
{
    public class GameResultUpdateDto
    {
        public int Id { get; set; }
        public byte SetNr { get; set; }
        public byte ScoreTeamMember { get; set; }
        public byte ScoreOpponent { get; set; }
    }
}
