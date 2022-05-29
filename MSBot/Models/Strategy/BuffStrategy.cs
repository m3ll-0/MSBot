using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Models.Strategy
{
    public interface BuffStrategy
    {
        int BuffAllCommandsDistributionLow { get; set; }
        int BuffAllCommandsDistributionHigh { get; set; }

        int PauseLongDistributionLow { get; set; }
        int PauseLongDistributionHigh { get; set; }
    }
}
