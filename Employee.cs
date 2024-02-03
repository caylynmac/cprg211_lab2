using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Employee : Object
    {
        private string _id;
        public string id
        {
            get { return _id; }
            set { _id = id; }
        }
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = name; }
        }
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = address; }
        }
        private string _phone;
        public string phone
        {
            get { return _phone; }
            set { _phone = phone; }
        }
        private long _sin;
        public long sin
        {
            get { return _sin; }
            set { _sin = sin; }
        }
        private string _dob;
        public string dob
        {
            get { return _dob; }
            set { _dob = dob; }
        }
        private string _dept;
        public string dept
        {
            get { return _dept; }
            set { _dept = dept; }
        }

        //private double _pay = 0.0;

        //public double pay
        //{
        //    get { return _pay; }
        //    set { _pay = pay; }
        //}
        public Employee()
        { }


        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept)
        {
            this._id = id;   
            this._name = name;
            this._address = address;
            this._phone = phone;
            this._sin = sin;
            this._dob = dob;
            this._dept = dept;
        }

        public virtual double GetPay()
        {
            return 0.0;
        }


        public override string ToString()
        {
            return $"ID: {id}\n Name: {name}\n Address: {address}\n Phone: {phone}\n SIN: {sin}\n DOB: {dob}\n Department: {dept}\n";
        }
    }
}
