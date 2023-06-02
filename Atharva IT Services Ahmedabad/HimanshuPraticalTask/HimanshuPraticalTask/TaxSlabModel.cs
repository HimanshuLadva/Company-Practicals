using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimanshuPraticalTask
{
    public class TaxSlabModel
    {
        public int RangeId { get; set; }
        public double LowerLimit { get; set; }
        public double UpperLimit { get; set; }
        public int percentage { get; set; }
    }
}
