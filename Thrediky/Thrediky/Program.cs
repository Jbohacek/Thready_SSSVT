using System.Security.Cryptography.X509Certificates;
using Thrediky.Vehicles;
using Thrediky.Managment;

namespace Thrediky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car auto = new Car("Skoda", 150);
            auto.StartMoving(new Road(50_000, 80));
            Console.ReadLine();
        }
    }
}