using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrediky.Managment
{
    internal class Road
    {
        public int Lenght;
        public int MaxSpeed;
        public double CurrentProgess = 0;
        public bool CestaDokonce = false;

        public Road(int lenght, int maxSpeed)
        {
            Lenght = lenght;
            MaxSpeed = maxSpeed;
            
        }
    }
}
