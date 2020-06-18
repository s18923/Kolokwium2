﻿using System;
using System.Collections.Generic;

namespace Kolokwium2.Models
{
    public partial class ChampionshipTeam
    {
        public int IdTeam { get; set; }
        public int IdChampionship { get; set; }
        public double? Score { get; set; }

        public virtual Championship IdChampionshipNavigation { get; set; }
        public virtual Team IdTeamNavigation { get; set; }
    }
}
