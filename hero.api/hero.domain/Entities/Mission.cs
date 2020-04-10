using System;
using System.Collections.Generic;
using Netploy.Common.Base.Entities;

namespace hero.domain.Entities
{
    public enum ThreatLevel
    {
        Wolf,
        Tiger,
        Demon,
        Dragon,
        God
    }
    public enum MissionStatus
    {
        OnHold,
        InProgress,
        Completed,
        Aborted
    }
    public class Mission : BaseEntity<int>
    {
        public string MissionName { get; set; }
        public string ThreatName { get; set; }
        public ThreatLevel ThreatLevel { get; set; }
        public IEnumerable<MissionHero> Heroes { get; set; }
        public MissionStatus Status { get; set; }
    }
}
