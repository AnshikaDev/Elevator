using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.Concurrent;

namespace Elevator
{
     class Elevator
    {
        private readonly ConcurrentDictionary<int, bool> _sorted = new ConcurrentDictionary<int, bool>();
        public  int TopFloor;

        public Elevator()
        {
           
        }

        public int CurrentFloor { get; set; } = 1;
        public Status Status { get; set; } = Status.Stopped;

        public void FloorRequest(int floor)
        {
            if (!_sorted.ContainsKey(floor))
                _sorted.TryAdd(floor, false);

            switch (Status)
            {
                case Status.GoingDown:
                    MoveDown();
                    break;

                case Status.Stopped:
                    if (CurrentFloor < floor)
                        MoveUp();
                    else
                        MoveDown();
                    break;

                case Status.GoingUp:
                    MoveUp();
                    break;

                default:
                    break;
            }
        }

        public void MoveUp()
        {
            var max = _sorted.OrderByDescending(x => x.Key).First();
            for (var i = CurrentFloor; i <= max.Key; i++) // Go to top most requested floor
                if (_sorted.ContainsKey(i))
                    Stop(i);
                else
                    continue;

            Status = Status.Stopped;
        }

        public void MoveDown()
        {
            var min = _sorted.OrderBy(x => x.Key).First();
            for (var i = CurrentFloor; i >= min.Key; i--)
                if (_sorted.ContainsKey(i))
                    Stop(i);
                else
                    continue;

            Status = Status.Stopped;
        }

        public void Stop(int floor)
        {
            _sorted.Remove(floor,out _);
            CurrentFloor = floor;
            Console.WriteLine("Stopped at: {0}", CurrentFloor);
        }
    }
}
