using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Models.Strategy
{
    public class JumpStrategyNormal : JumpStrategy
    {
        public int JumpSingleDistributionLow { get; set; } = 0;
        public int JumpSingleDistributionHigh { get; set; } = 25;

        public int JumpDoubleDistributionLow { get; set; } = 25;
        public int JumpDoubleDistributionHigh { get; set; } = 50;

        public int JumpDoubleHighDistributionLow { get; set; } = 50;
        public int JumpDoubleHighDistributionHigh { get; set; } = 75;

        public int PauseDistributionLow { get; set; } = 75;
        public int PauseDistributionHigh { get; set; } = 100;
    }
}
