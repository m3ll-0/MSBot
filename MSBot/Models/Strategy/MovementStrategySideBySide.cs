using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Models.Strategy
{
    internal class MovementStrategySideBySide : MovementStrategy
    {
        public int MoveLeftOfMapDistributionLow { get; set; } = 0;
        public int MoveLeftOfMapDistributionHigh { get; set; } = 40;

        public int MoveRightOfMapDistributionLow { get; set; } = 40;
        public int MoveRightOfMapDistributionHigh { get; set; } = 80;

        public int MoveShortLeftDistributionLow { get; set; } = 80;
        public int MoveShortLeftDistributionHigh { get; set; } = 83;

        public int MoveShortRightDistributionLow { get; set; } = 83;
        public int MoveShortRightDistributionHigh { get; set; } = 86;

        public int MoveUpDistributionLow { get; set; } = 86;
        public int MoveUpDistributionHigh { get; set; } = 91;

        public int MoveDownDistributionLow { get; set; } = 91;
        public int MoveDownDistributionHigh { get; set; } = 96;


        public int PauseDistributionLow { get; set; } = 96;
        public int PauseDistributionHigh { get; set; } = 100;
    }
}
