
public class Elevator
{
    private readonly int _id;

    public List<int> Requests { get; set; } = new List<int>();
    public Direction Direction { get; set; } = Direction.Up;
    public int CurrentFloor { get; set; } = 1;

    public Elevator(int id)
    {
        _id = id;
    }

    public void AddRequest(int floor)
    {
        if (!Requests.Contains(floor))
        {
            Requests.Add(floor);
            Console.WriteLine($"Elevator {_id}: Added request for floor {floor}");
        }
    }

    public void Move()
    {
        if (Requests.Count == 0) return;

        var upwardRequests = Requests.Where(x => x > CurrentFloor).ToList();
        var downwardRequests = Requests.Where(x => x < CurrentFloor).ToList();

        if (Direction == Direction.Up && upwardRequests.Any())
        {
            var targetFloor = upwardRequests.Min();
            CurrentFloor++;
            Console.WriteLine($"Elevator {_id} is moving up to floor {CurrentFloor}");

            if (CurrentFloor == targetFloor)
            {
                ArriveAtFloor(targetFloor);
                return;
            }
        }

        if (Direction == Direction.Down && downwardRequests.Any())
        {
            var targetFloor = downwardRequests.Max();
            CurrentFloor--;
            Console.WriteLine($"Elevator {_id} is moving down to floor {CurrentFloor}");

            if (CurrentFloor == targetFloor)
            {
                ArriveAtFloor(targetFloor);
                return;
            }
        }


        if (Direction == Direction.Up && !upwardRequests.Any())
        { 
            Direction = Direction.Down;
            return;
        }

        if (Direction == Direction.Down && !downwardRequests.Any())
        {
            Direction = Direction.Up;
            return;
        }

    }

    private void ArriveAtFloor(int floor)
    {
        Console.WriteLine($"Elevator {_id} has stopped at floor {floor}");
        Requests.Remove(floor);

        SimulatePassengerExchange();
    }

    private void SimulatePassengerExchange()
    {
        Console.WriteLine($"Passengers entering/leaving the elevator {_id} at floor {CurrentFloor}.");
        Thread.Sleep(10000);
    }
}