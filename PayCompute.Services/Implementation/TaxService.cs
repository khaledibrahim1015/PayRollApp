using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCompute.Services.Implementation
{
    public class TaxService : ITaxService
    {
        private decimal taxRate;
        private decimal taxAmount;
        public decimal TaxAmount(decimal totalAmount)
        {
            
            if(totalAmount <= 1250)
            {
                taxRate = .0m;
                taxAmount = totalAmount * taxRate;
            }
            else if(totalAmount > 1250 && totalAmount <= 2500)
            {
                taxRate = 0.025m;
                taxAmount = ((1250 - 0) * .0m) + ((totalAmount - 1250) * taxRate);
            }
            else if( totalAmount > 2500 && totalAmount <= 3750)
            {
                taxRate = 0.10m;
                taxAmount = ((1250 - 0) * 0.0m) + ((2500 - 1250) * 0.025m) + ((totalAmount - 2500) * taxRate);
            }
            else if(totalAmount > 3750 && totalAmount <= 5000)
            {
                taxRate = 0.15m;
                taxAmount = ((1250 - 0) * 0.0m) + ((2500 - 1250) * 0.025m) + ((3750 - 2500) * 0.10m) + ((totalAmount - 3750) * taxRate);
            }
            else if (totalAmount > 5000 && totalAmount <= 16666)
            {
                taxRate = 0.20m;
                taxAmount = ((1250 - 0) * 0.0m) + ((2500 - 1250) * 0.025m) + ((3750 - 2500) * 0.10m) +
                    ((5000 - 3750) * 0.15m) + ((totalAmount - 5000) * taxRate);
            }
            else if (totalAmount > 16666 && totalAmount <= 33333)
            {
                taxRate = 0.225m;
                taxAmount = ((1250 - 0) * 0.0m) + ((2500 - 1250) * 0.025m) + ((3750 - 2500) * 0.10m) +
                    ((5000 - 3750) * 0.15m) +((16666-5000)* 0.20m) + ((totalAmount - 16666) * taxRate);
            }
            else if (totalAmount>33333)
            {
                taxRate = 0.25m;
                taxAmount= ((1250 - 0) * 0.0m) + ((2500 - 1250) * 0.025m) + ((3750 - 2500) * 0.10m) +
                    ((5000 - 3750) * 0.15m) + ((16666 - 5000) * 0.20m)+((33333-16666)* 0.225m) + ((totalAmount - 33333) * taxRate);
            }



        }
    }
}
