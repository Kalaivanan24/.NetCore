using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    internal class Program
    {

        public interface IVehicle
        {
            void Drive(int speed);
        }

        public class Car : IVehicle
        {
            public void Drive(int speed)
            {
                Console.WriteLine($"Driving a car at speed {speed} mph");
            }
        }

        public class Truck : IVehicle
        {
            public void Drive(int speed)
            {
                Console.WriteLine($"Driving a truck at speed {speed} mph");
            }
        }

        public class VehicleFactory
        {
            private Dictionary<string, IVehicle> _vehicles = new Dictionary<string, IVehicle>();

            public IVehicle GetVehicle(string type)
            {
                if (!_vehicles.TryGetValue(type, out IVehicle vehicle))
                {
                    switch (type)
                    {
                        case "car":
                            vehicle = new Car();
                            break;
                        case "truck":
                            vehicle = new Truck();
                            break;
                            // Add more vehicle types here
                    }
                    _vehicles[type] = vehicle;
                }
                return vehicle;
            }
        }



        static void Main(string[] args)
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            IVehicle car1 = vehicleFactory.GetVehicle("car");
            IVehicle car2 = vehicleFactory.GetVehicle("car");
            IVehicle truck1 = vehicleFactory.GetVehicle("truck");
            IVehicle truck2 = vehicleFactory.GetVehicle("truck");

            car1.Drive(60);
            car2.Drive(75);
            truck1.Drive(50);
            truck2.Drive(65);
        }
    }

}
