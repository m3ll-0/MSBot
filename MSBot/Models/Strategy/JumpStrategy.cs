using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSBot.Models.Strategy
{
    public interface JumpStrategy
    {
        int JumpSingleDistributionLow { get; set; }
        int JumpSingleDistributionHigh { get; set; }

        int JumpDoubleDistributionLow { get; set; }
        int JumpDoubleDistributionHigh { get; set; }

        int JumpDoubleHighDistributionLow { get; set; }
        int JumpDoubleHighDistributionHigh { get; set; }

        int PauseDistributionLow { get; set; }
        int PauseDistributionHigh { get; set; }
    }
}
