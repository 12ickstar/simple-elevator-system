[TestFixture]
public class BuildingTests
{
    [Test]
    public void AssignElevator_ShouldSelectClosestElevator_MovingInCorrectDirection()
    {
        var building = new Building(floors: 10, elevatorCount: 4);

        building.Elevators[0].CurrentFloor = 1;
        building.Elevators[0].Direction = Direction.Up;

        building.Elevators[1].CurrentFloor = 5;
        building.Elevators[1].Direction = Direction.Down;

        building.Elevators[2].CurrentFloor = 9;
        building.Elevators[2].Direction = Direction.Down;

        building.Elevators[3].CurrentFloor = 8;

        building.AssignElevator(4, Direction.Up);

        Assert.Contains(4, building.Elevators[1].Requests, "Elevator 2 should handle the request for floor 4.");
        Assert.IsEmpty(building.Elevators[0].Requests, "Elevator 1 should not handle the request.");
        Assert.IsEmpty(building.Elevators[2].Requests, "Elevator 3 should not handle the request.");
        Assert.IsEmpty(building.Elevators[3].Requests, "Elevator 4 should not handle the request.");
    }

    [Test]
    public void AssignElevator_ShouldSelectIdleElevator_WhenNoElevatorsMovingInDirection()
    {
        var building = new Building(floors: 10, elevatorCount: 4);

        building.Elevators[0].CurrentFloor = 3;
        building.Elevators[0].Direction = Direction.Down;
        building.Elevators[0].Requests = [2];

        building.Elevators[1].CurrentFloor = 5;
        building.Elevators[1].Direction = Direction.Down;
        building.Elevators[1].Requests = [3, 4];

        building.Elevators[2].CurrentFloor = 9;
        building.Elevators[2].Direction = Direction.Up;
        building.Elevators[2].Requests = [10];

        building.Elevators[3].CurrentFloor = 8;
        building.Elevators[3].Requests = [];

        building.AssignElevator(7, Direction.Up);

        Assert.Contains(7, building.Elevators[3].Requests, "Elevator 4 should handle the request for floor 7.");
    }

    [Test]
    public void AssignElevator_ShouldSelectElevator_WhenMultipleElevatorsAreIdle()
    {
        var building = new Building(10, 3); 

        building.Elevators[0].CurrentFloor = 3;
        building.Elevators[1].CurrentFloor = 5;
        building.Elevators[2].CurrentFloor = 8;

        building.AssignElevator(4, Direction.Up);

        Assert.Contains(4, building.Elevators[0].Requests, "Elevator 1 should handle the request for floor 4.");
    }
}