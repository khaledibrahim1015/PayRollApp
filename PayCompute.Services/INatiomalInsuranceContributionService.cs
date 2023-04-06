using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCompute.Services
{
    public  interface INatiomalInsuranceContributionService
    {
        decimal NIContribution(decimal totalAmount);

    }
}
