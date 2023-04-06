using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCompute.Services.Implementation
{
    public class NationalInsuranceContribution : INatiomalInsuranceContributionService
    {
        private decimal NICRate;
        private decimal NICAmount;

        public decimal NIContribution(decimal totalAmount)
        {
          if(totalAmount<1700)
            {
                // Lower
                NICRate = 0m;
                NICAmount = 0m;
            }
          else if(totalAmount>=1700&&totalAmount<=10900)
            {
                // between primary Threshold and Upper Earnings Limit
                NICRate = .1875m;
                NICAmount = (totalAmount - 1700) * NICRate;
            }
          else if(totalAmount>10900)
            {
                // Above Upper Earnings 
                NICRate = .21m;
                NICAmount = ((10900 - 1700) * 0.1875m) + ((totalAmount - 10900) * NICRate);
            }

            return NICAmount;
        }
    }
}
