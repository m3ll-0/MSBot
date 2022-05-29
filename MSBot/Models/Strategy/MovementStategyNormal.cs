using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Models.Strategy
{
    internal class MovementStategyNormal : MovementStrategy
    {
        public int MoveLeftOfMapDistributionLow { get; set; } = 0;
        public int MoveLeftOfMapDistributionHigh { get; set; } = 35;

        public int MoveRightOfMapDistributionLow { get; set; } = 35;
        public int MoveRightOfMapDistributionHigh { get; set; } = 70;

        public int MoveShortLeftDistributionLow { get; set; } = 75;
        public int MoveShortLeftDistributionHigh { get; set; } = 80;

        public int MoveShortRightDistributionLow { get; set; } = 80;
        public int MoveShortRightDistributionHigh { get; set; } = 85;

        public int MoveUpDistributionLow { get; set; } = 85;
        public int MoveUpDistributionHigh { get; set; } = 90;

        public int MoveDownDistributionLow { get; set; } = 90;
        public int MoveDownDistributionHigh { get; set; } = 95;

        public int PauseDistributionLow { get; set; } = 95;
        public int PauseDistributionHigh { get; set; } = 100;
    }
}
