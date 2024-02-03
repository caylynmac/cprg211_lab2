using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class PartTime : Employee
    {
        private double rate { get; set; }
        private double hours { get; set; }

        //public Salaried()
        //{ }

        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }

        public override double GetPay()
        {
            double pay = this.rate * this.hours;
            return Math.Round(pay, 2);
        }
        public override string ToString()
        {
            return base.ToString() + " Pay: $" + this.GetPay() + "\n\n";
        }
    }
}
