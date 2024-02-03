using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Wages : Employee
    {
        private double rate { get; set; }
        private double hours { get; set; }

        public Wages()
        { }

        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }
        public override double GetPay()
        {
            if (this.hours > 40) // overtime
            {
                double pay = (this.rate * 40) + (this.rate * 1.5 * (this.hours - 40));
  
                return Math.Round(pay, 2);
            }
            else
            {
                double pay = this.rate * this.hours;
                return Math.Round(pay, 2);
            }
        }
        public override string ToString()
        {
            return base.ToString() + " Pay: $" + this.GetPay() + "\n\n";
        }
    }

}
