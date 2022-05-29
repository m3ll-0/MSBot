using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Strategy
{
    internal class AttackStrategyNormal : AttackStrategy
    {
        public int AttackNormalDistributionLow { get; set; } = 0;
        public int AttackNormalDistributionHigh { get; set; } = 50;

        public int AttackSwipeDistributionLow { get; set; } = 50;
        public int AttackSwipeDistributionHigh { get; set; } = 60;

        public int AttackSlashDistributionLow { get; set; } = 60;
        public int AttackSlashDistributionHigh { get; set; } = 68;

        public int AttackCubeDistributionLow { get; set; } = 68;
        public int AttackCubeDistributionHigh { get; set; } = 74;

        public int AttackChargeDistributionLow { get; set; } = 74;
        public int AttackChargeDistributionHigh { get; set; } = 82;

        public int PauseDistributionLow { get; set; } = 82;
        public int PauseDistributionHigh { get; set; } = 100;
    }
}
