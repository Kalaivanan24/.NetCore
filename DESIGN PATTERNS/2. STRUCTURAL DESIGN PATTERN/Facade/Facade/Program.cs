using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    internal class Program
    {

        // Subsystem: Hotel booking system
        public class HotelBooking
        {
            public void BookHotel(string destination, DateTime checkInDate, DateTime checkOutDate)
            {
                Console.WriteLine($"Booked hotel in {destination} from {checkInDate.ToShortDateString()} to {checkOutDate.ToShortDateString()}");
            }
        }

        // Subsystem: Flight booking system
        public class FlightBooking
        {
            public void BookFlight(string source, string destination, DateTime departureDate)
            {
                Console.WriteLine($"Booked flight from {source} to {destination} on {departureDate.ToShortDateString()}");
            }
        }

        // Subsystem: Car rental system
        public class CarRental
        {
            public void RentCar(string destination, DateTime pickupDate, DateTime returnDate)
            {
                Console.WriteLine($"Rented a car in {destination} from {pickupDate.ToShortDateString()} to {returnDate.ToShortDateString()}");
            }
        }


        // Facade: Vacation booking system
        public class VacationBookingSystem
        {
            private HotelBooking _hotelBooking;
            private FlightBooking _flightBooking;
            private CarRental _carRental;

            public VacationBookingSystem()
            {
                _hotelBooking = new HotelBooking();
                _flightBooking = new FlightBooking();
                _carRental = new CarRental();
            }

            public void BookVacation(string destination, DateTime checkInDate, DateTime checkOutDate, DateTime departureDate, DateTime returnDate)
            {
                _hotelBooking.BookHotel(destination, checkInDate, checkOutDate);
                _flightBooking.BookFlight("Your City", destination, departureDate);
                _carRental.RentCar(destination, departureDate, returnDate);
                Console.WriteLine("Vacation booked successfully!");
            }
        }



        static void Main(string[] args)
        {
            VacationBookingSystem vacationBookingSystem = new VacationBookingSystem();

            DateTime checkInDate = DateTime.Now.AddDays(7);
            DateTime checkOutDate = checkInDate.AddDays(5);
            DateTime departureDate = checkInDate.AddDays(0);
            DateTime returnDate = checkOutDate.AddDays(1);

            vacationBookingSystem.BookVacation("Paris", checkInDate, checkOutDate, departureDate, returnDate);
        }
    }
}
