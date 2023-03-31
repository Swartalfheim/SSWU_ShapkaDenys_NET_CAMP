using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class Pump
    {
        private double _power; // кіловати
        private double _flowRate; // метри кубічні на годину
        public Pump(double power, double flowRate)
        {
            Power = power;
            FlowRate = flowRate;
        }

        public double Power
        {
            get
            {
                return _power;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(paramName: nameof(value), message: "Потужність має бути вище 0");
                }

                _power = value;
            }
        }

        public double FlowRate
        {
            get
            {
                return _flowRate;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(paramName: nameof(value), message: "Швидкість потоку має бути вище 0");
                }

                _flowRate = value;
            }
        }

        public double Work(double hours)
        {
            throw new NotImplementedException(); // повертає обсяг, вироблений за певний період часу
        }

        public override string ToString()
        {
            return $"Насос: потужність: {Power} кВт/год, швидкість потоку: {FlowRate} м^3/год";
        }
    }
}
