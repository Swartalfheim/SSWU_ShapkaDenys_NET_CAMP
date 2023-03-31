using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class User
    {
        private static int nextId = 1;
        private float _waterConsumption; // м^3/год
        public User(float waterConsumption)
        {
            Id = nextId++;
            WaterConsumption = waterConsumption;
        }

        public int Id { get; init; }
        public float WaterConsumption
        {
            get
            {
                return _waterConsumption;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(paramName: nameof(value), message: "Норма витрати не може бути негативною");
                }

                _waterConsumption = value;
            }
        }

        public override string ToString()
        {
            return $"Ідентифікатор користувача: {Id}, норма витрати води: {WaterConsumption} м^3/год";
        }
    }
}
