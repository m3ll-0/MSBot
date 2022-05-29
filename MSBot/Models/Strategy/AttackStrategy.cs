using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Strategy
{
    public interface AttackStrategy
    {
        int AttackNormalDistributionLow { get; set; }
        int AttackNormalDistributionHigh { get; set; }

        int AttackSwipeDistributionLow { get; set; }
        int AttackSwipeDistributionHigh { get; set; }

        int AttackSlashDistributionLow { get; set; }
        int AttackSlashDistributionHigh { get; set; }

        int AttackCubeDistributionLow { get; set; }
        int AttackCubeDistributionHigh { get; set; }

        int AttackChargeDistributionLow { get; set; }
        int AttackChargeDistributionHigh { get; set; }

        int PauseDistributionLow { get; set; }
        int PauseDistributionHigh { get; set; }

    }
}
