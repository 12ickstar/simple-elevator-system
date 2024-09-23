
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

        var targetFloor = Requests.OrderBy(f => Math.Abs(f - CurrentFloor)).First();

        Direction = CurrentFloor > targetFloor ? Direction.Down : Direction.Up;
        
        if (Direction == Direction.Up)
        {
            CurrentFloor++;
            Console.WriteLine($"Elevator {_id} is moving up to floor {CurrentFloor}");
        }

        if (Direction == Direction.Down)
        {
            CurrentFloor--;
            Console.WriteLine($"Elevator {_id} is moving down to floor {CurrentFloor}");
        }

        if (CurrentFloor == targetFloor)
        {
            ArriveAtFloor(targetFloor);
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