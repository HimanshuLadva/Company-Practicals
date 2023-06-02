using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimanshuPraticalTask.interfaces
{
    public interface ICalculateIncomeTax
    {
        public double CalculateTaxableAmount();
        public void CalculatePayableTaxAmount();
    }
}
