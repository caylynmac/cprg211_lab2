using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Salaried : Employee
    {
        private double _salary;
        public double salary
        {
            get { return _salary; }
            set { _salary = salary; }
        }

        public Salaried()
        {

            this._salary = 999999999.9;
        }

        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary) : base(id, name, address, phone, sin, dob, dept)
        {
            this._salary = salary;
        }

        public override double GetPay()
        {
            double pay = this._salary;
            
            return pay;
        }
        public override string ToString()
        {
            return base.ToString() + " Pay: $" + this.GetPay() + "\n\n";
        }
    }
}
