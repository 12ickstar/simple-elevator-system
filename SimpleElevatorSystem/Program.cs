var random = new Random();
var building = new Building(floors: 10, elevatorCount: 4);

while (true)
{
    var requestedFloor = random.Next(1, building.Floors + 1);
    var requestedDirection = random.Next(2) == 0 ? Direction.Up : Direction.Down;

    var isDownRequestFromTheFirstFloor = requestedFloor == 1 && requestedDirection == Direction.Down;
    var isUpRequestFromTheTopFloor = requestedFloor == building.Floors && requestedDirection == Direction.Up;

    if (isDownRequestFromTheFirstFloor || isUpRequestFromTheTopFloor)
    {
        continue;
    }

    Console.WriteLine($"Request received: {requestedDirection} request on floor {requestedFloor}");

    building.AssignElevator(requestedFloor, requestedDirection);

    foreach (var elevator in building.Elevators)
    {
        elevator.Move();
    }

    Thread.Sleep(10000);
}