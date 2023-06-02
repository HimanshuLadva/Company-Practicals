using HimanshuPraticalTask.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimanshuPraticalTask
{
    // Here I use interface
    public class TaxSlabForMenORWomen : ITaxSlabForMenORWomen
    {
        private int _age;
        private DateTime _birthDate;
        private string _gender;
        protected List<TaxSlabModel> taxSlabs = new List<TaxSlabModel>(4);

        public TaxSlabForMenORWomen(string gender, DateTime birthDate)
        {
            _birthDate = birthDate;
            _gender = gender;
            calAge();
            giveRange();
        }

        public double calPer(double num, int percentage)
        {
            if (num < 0)
            {
                num = -num;
            }
            return (num * percentage) / 100;
        }

        public int calAge()
        {
            DateTime today = DateTime.Today;
            _age = today.Year - _birthDate.Year;

            if (today < _birthDate.AddYears(_age))
            {
                _age--;
            }

            return _age;
        }

        public void giveRange()
        {
            if (_gender.ToLower() == "m" && _age < 60)
            {
                taxSlabs.Add(new TaxSlabModel()
                {
                    RangeId = 1,
                    LowerLimit = 0,
                    UpperLimit = 160000,
                    percentage = 0
                });
                taxSlabs.Add(new TaxSlabModel()
                {
                    RangeId = 2,
                    LowerLimit = 160001,
                    UpperLimit = 300000,
                    percentage = 10
                });
                taxSlabs.Add(new TaxSlabModel()
                {
                    RangeId = 3,
                    LowerLimit = 300001,
                    UpperLimit = 500000,
                    percentage = 20
                });
                taxSlabs.Add(new TaxSlabModel()
                {
                    RangeId = 4,
                    LowerLimit = 500001,
                    UpperLimit = 0,
                    percentage = 30
                });
            }
            else if (_gender.ToLower() == "f" && _age < 60)
            {
                taxSlabs.Add(new TaxSlabModel()
                {
                    RangeId = 1,
                    LowerLimit = 0,
                    UpperLimit = 190000,
                    percentage = 0
                });
                taxSlabs.Add(new TaxSlabModel()
                {
                    RangeId = 2,
                    LowerLimit = 190001,
                    UpperLimit = 300000,
                    percentage = 10
                });
                taxSlabs.Add(new TaxSlabModel()
                {
                    RangeId = 3,
                    LowerLimit = 300001,
                    UpperLimit = 500000,
                    percentage = 20
                });
                taxSlabs.Add(new TaxSlabModel()
                {
                    RangeId = 4,
                    LowerLimit = 500001,
                    UpperLimit = 0,
                    percentage = 30
                });
            }
            else
            {
                taxSlabs.Add(new TaxSlabModel()
                {
                    RangeId = 1,
                    LowerLimit = 0,
                    UpperLimit = 240000,
                    percentage = 0
                });
                taxSlabs.Add(new TaxSlabModel()
                {
                    RangeId = 2,
                    LowerLimit = 240001,
                    UpperLimit = 300000,
                    percentage = 10
                });
                taxSlabs.Add(new TaxSlabModel()
                {
                    RangeId = 3,
                    LowerLimit = 300001,
                    UpperLimit = 500000,
                    percentage = 20
                });
                taxSlabs.Add(new TaxSlabModel()
                {
                    RangeId = 4,
                    LowerLimit = 500001,
                    UpperLimit = 0,
                    percentage = 30
                });
            }
        }
    }
}
