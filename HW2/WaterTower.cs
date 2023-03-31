using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class WaterTower
    {
        private int _volume; // м^3
        private int _currentVolume;
        private Pump _pump;
        public WaterTower(int volume, Pump pump)
        {
            Volume = volume;
            pump = _pump;
            Users = new List<User>();
        }

        public int Volume
        {
            get
            {
                return _volume;
            }

            init
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(paramName: nameof(value), message: "Загальний обсяг має бути вищим за 0");
                }

                _volume = value;
            }
        }

        public int CurrentVolume
        {
            get
            {
                return _currentVolume;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(paramName: nameof(value), message: "Обсяг не може бути менше 0");
                }

                _currentVolume = value;
            }
        }

        public List<User> Users { get; set; }
        public void ConnectUser(User user)
        {
            Users.Add(user);
        }

        public bool DisconnectUser(int id)
        {
            return Users.Remove(Users.FirstOrDefault(users => users.Id == id));
        }

        public void CheckVolume()
        {
            throw new NotImplementedException();
        }

        public void GiveWater(float hours)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Водонапірна башта: максимальний обсяг: {Volume} m^3, поточний обсяг: {CurrentVolume} m^3\n  підключених користувачів: {Users.Count()}, " +
                $"поточна загальна норма споживання: {Users.Select(user => user.WaterConsumption).Sum()} м^3/год";
        }
    }
}
