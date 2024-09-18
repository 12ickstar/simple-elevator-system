public class Building
{
    public List<Elevator> Elevators { get; private set; } = new List<Elevator>();

    public int Floors { get; private set; }

    private Building() { }
    
    public Building(int floors, int elevatorCount)
    {
        Floors = floors;
        Elevators = Enumerable.Range(1, elevatorCount).Select(id => new Elevator(id)).ToList();
    }

    public void AssignElevator(int requestedFloor, Direction requestedDirection)
    {
        var bestElevator = Elevators
            .Where(e => e.Requests.Count == 0 ||
                (requestedDirection == Direction.Up && e.Direction == Direction.Up && e.CurrentFloor <= requestedFloor) ||
                (requestedDirection == Direction.Down && e.Direction == Direction.Down && e.CurrentFloor >= requestedFloor))
            .OrderBy(e => Math.Abs(e.CurrentFloor - requestedFloor))
            .FirstOrDefault();

        bestElevator?.AddRequest(requestedFloor);
    }
}
