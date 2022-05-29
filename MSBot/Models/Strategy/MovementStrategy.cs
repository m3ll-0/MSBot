using MSBot.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Models.Strategy
{
    public interface MovementStrategy
    {
        int MoveLeftOfMapDistributionLow { get; set; }
        int MoveLeftOfMapDistributionHigh { get; set; }

        int MoveRightOfMapDistributionLow { get; set; }
        int MoveRightOfMapDistributionHigh { get; set; }

        int MoveShortLeftDistributionLow { get; set; }
        int MoveShortLeftDistributionHigh { get; set; }

        int MoveShortRightDistributionLow { get; set; }
        int MoveShortRightDistributionHigh { get; set; }

        int MoveUpDistributionLow { get; set; }
        int MoveUpDistributionHigh { get; set; }

        int MoveDownDistributionLow { get; set; }
        int MoveDownDistributionHigh { get; set; }

        int PauseDistributionLow { get; set; }
        int PauseDistributionHigh { get; set; }
    }
}
