using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrediky.Managment;

namespace Thrediky.Vehicles
{
    internal class Car : Vehicle
    {
        string Name;
        public Car(string nazev, int maxspeed)
        {
            Name= nazev;
            MaxSpeed = maxspeed;
        }
        
    }
}
