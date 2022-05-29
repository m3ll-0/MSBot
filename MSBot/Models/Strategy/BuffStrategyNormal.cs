using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Models.Strategy
{
    public class BuffStrategyNormal : BuffStrategy
    {
        public int BuffAllCommandsDistributionLow { get; set; } = 0;
        public int BuffAllCommandsDistributionHigh { get; set; } = 20;

        public int PauseLongDistributionLow { get; set; } = 20;
        public int PauseLongDistributionHigh { get; set; } = 100;
    }
}
