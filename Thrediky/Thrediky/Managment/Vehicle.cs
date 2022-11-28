using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrediky.Managment
{
    internal class Vehicle : IMovable
    {
        public int MaxSpeed { get ; set; }

        private void Move(ref Road Cesta)
        {
            while (Cesta.Lenght > Cesta.CurrentProgess)
            {
                Thread.Sleep(1);

                Cesta.CurrentProgess += Math.Min(Cesta.MaxSpeed, MaxSpeed);

                Console.WriteLine(Math.Round((double)Cesta.CurrentProgess / (double)Cesta.Lenght, 2) + "%");
            }
            Cesta.CestaDokonce = true;
        }

        public void StartMoving(Road Cesta)
        {
            if (Cesta.CestaDokonce == false)
            {
                Task.Run(() => Move(ref Cesta));
            }
        }

        public void BeeBeeB()
        {
            Console.WriteLine("TuuT");
        }
    }
}
