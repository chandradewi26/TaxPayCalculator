using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxPayCalculator
{
    public class Resident
    {
        private decimal TaxableIncome { get; }
        private string IncomeYear { get; }
        private decimal Tax { get; }
        private decimal TaxOffset { get; }
        private bool TaxThreshold { get; }

        public Resident()
        {

        }
    }
}
