using System;
using System.Collections.Generic;
using System.Text;

namespace Elevator
{
    static class ElevatorRegulator
    {
        private static readonly Elevator _elevator;
        public static Elevator Elevator { get { return _elevator; } set { value = _elevator; } }
        static object _lock = new object();
        static ElevatorRegulator()
        {
            if(_elevator!= null)
            {
                lock (_lock) {
                    if (_elevator != null)
                    {
                        _elevator = new Elevator();
                        _elevator.TopFloor = 5;
                    }
                    
                }
            }
        }
        public static  void ButtonPressed(int floor)
        {
            _elevator.FloorRequest(3);
            //_elevator.AddRequest(10);
            //_elevator.AddRequest(5);
            //_elevator.AddRequest(2);
            //_elevator.AddRequest(9);
            //_elevator.AddRequest(6);
        }
    }
}
