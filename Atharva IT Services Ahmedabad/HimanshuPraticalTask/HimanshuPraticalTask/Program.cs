using HimanshuPraticalTask;
using HimanshuPraticalTask.interfaces;

namespace HimanshuPracticalTask
{
    // Here I use both Inheritance and Inferface
    public class CalculateIncomeTax : TaxSlabForMenORWomen, ICalculateIncomeTax
    {
        private readonly double _income;
        private readonly double _investments;
        private readonly double _homeLoanRent;
        private double _taxableAmount;
        private double _payableTaxAmount;

        public CalculateIncomeTax(double income, double investments, double homeLoanRent, string gender, DateTime birthDate) : base(gender, birthDate)
        {
            _income = income;
            _investments = investments;
            _homeLoanRent = homeLoanRent;
        }

        public double CalculateTaxableAmount()
        {
            //if (_income < 160000)
            //{
            //    _taxableAmount = 0;
            //    return _taxableAmount;
            //}
            double firstDeduction = calPer(_income, 20) > calPer(_homeLoanRent, 80) ? calPer(_homeLoanRent, 80) : calPer(_income, 20);

            double secondDeduction = _investments <= 100000 ? _investments : 100000;

            _taxableAmount = _income - firstDeduction - secondDeduction;

            return _taxableAmount;
        }

        public void CalculatePayableTaxAmount()
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Tax Calculation Result");
            Console.WriteLine("---------------------------------------------------");
            _taxableAmount = CalculateTaxableAmount();
            _payableTaxAmount = 0;
            if (_taxableAmount <= taxSlabs[0].UpperLimit)
            {
                Console.WriteLine("Taxable Amount: " + _taxableAmount);
                Console.Write("Payable Tax Amount: " + _payableTaxAmount);
                return;
            }
            if (_taxableAmount >= taxSlabs[1].LowerLimit)
            {
                double deduction = _taxableAmount > taxSlabs[1].UpperLimit ? calPer(taxSlabs[1].UpperLimit - taxSlabs[0].UpperLimit, taxSlabs[1].percentage) : calPer(_taxableAmount - taxSlabs[0].UpperLimit, taxSlabs[1].percentage);
                _payableTaxAmount += deduction;
            }
            if (_taxableAmount >= taxSlabs[2].LowerLimit)
            {
                double deduction = _taxableAmount > taxSlabs[2].UpperLimit ? calPer(taxSlabs[2].UpperLimit - taxSlabs[1].UpperLimit, taxSlabs[2].percentage) : calPer(_taxableAmount - taxSlabs[1].UpperLimit, taxSlabs[2].percentage);
                _payableTaxAmount += deduction;
            }
            if (_taxableAmount >= taxSlabs[3].LowerLimit)
            {
                //Console.WriteLine("Taxable Amount: " + _taxableAmount);
                double deduction = calPer(_taxableAmount - taxSlabs[2].UpperLimit, taxSlabs[3].percentage);
                _payableTaxAmount += deduction;
            }
            Console.WriteLine("Taxable Amount: " + _taxableAmount);
            Console.WriteLine("Payable Tax Amount: " + _payableTaxAmount);
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("===================================================");
                Console.WriteLine("Tax Calculator");
                Console.WriteLine("===================================================");

                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Enter Person Details");
                Console.WriteLine("---------------------------------------------------");
                // Get user input for Name
                Console.Write("Name                   : ");
                string? name = Convert.ToString(Console.ReadLine());

                // Get user input for birthdate
                Console.Write("Birthdate [DD/MM/YYYY] : ");
                DateTime birthDate = Convert.ToDateTime(Console.ReadLine());

                // Get user input for gender
                Console.Write("Gender [M/F]           : ");
                string? gender = Convert.ToString(Console.ReadLine());

                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Enter Account Details");
                Console.WriteLine("---------------------------------------------------");

                // Get user input for income
                Console.Write("Income                 : ");
                double income = Convert.ToDouble(Console.ReadLine());

                // Get user input for investments
                Console.Write("Investments            : ");
                double investments = Convert.ToDouble(Console.ReadLine());

                // Get user input for home loan/rent
                Console.Write("House Loan/rent        : ");
                double homeLoanRent = Convert.ToDouble(Console.ReadLine());

                CalculateIncomeTax calculateIncomeTax = new CalculateIncomeTax(income, investments, homeLoanRent, gender!, birthDate);
                calculateIncomeTax.CalculatePayableTaxAmount();
            }
            catch(Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Oops Some Error Occured!!!");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Do you want to continue [Y/N]: ");
            string restar = Console.ReadLine();
            if (restar!.ToUpper() == "Y")
            {
                Console.Clear();
                Main(args);
            }
        }
    }
}