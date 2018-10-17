using System;

namespace Elevator
{
    internal class Request
    {
        public Request(int floor)
        {
            Floor = floor;
        }

        public int Floor { get; set; }
    }
    class Program
    {
        private const string _quit = "q";
        static void Main(string[] args)
        {
            ElevatorRegulator.Elevator = new Elevator();
            var input = string.Empty;

            while (input != _quit)
            {
                Console.Write("Enter floor: ");
                input = Console.ReadLine();
                int floor;
                if (int.TryParse(input, out floor))
                    ElevatorRegulator.ButtonPressed(floor);
                else if (input == _quit)
                    Console.WriteLine("GoodBye!");
                else
                    Console.WriteLine("You have pressed an incorrect floor, Please try again");
            }
        }
    }
}
