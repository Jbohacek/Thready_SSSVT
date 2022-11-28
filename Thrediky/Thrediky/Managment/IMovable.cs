using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrediky.Managment
{
    internal interface IMovable
    {
        public int MaxSpeed { get; set; }
        

        abstract void BeeBeeB();
    }
}
