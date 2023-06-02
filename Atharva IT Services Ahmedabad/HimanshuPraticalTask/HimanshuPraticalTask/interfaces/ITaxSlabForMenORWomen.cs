using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimanshuPraticalTask.interfaces
{
    public interface ITaxSlabForMenORWomen
    {
        public double calPer(double num, int percentage);
        
        public int calAge();
        
        public void giveRange();
    }
}
