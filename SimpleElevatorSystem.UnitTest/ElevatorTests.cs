[TestFixture]
public class ElevatorTests
{
    [Test]
    public void AddRequest_ShouldAddNewRequestIfNotPresent()
    {
        var elevator = new Elevator(1);

        elevator.AddRequest(5);

        Assert.Contains(5, elevator.Requests, "The request for floor 5 should be added to the elevator's request list.");
    }

    [Test]
    public void AddRequest_ShouldNotAddDuplicateRequest()
    {
        var elevator = new Elevator(1);
        
        elevator.AddRequest(5);
        elevator.AddRequest(5); 

        Assert.AreEqual(1, elevator.Requests.Count, "Duplicate requests should not be added.");
    }

    [Test]
    public void Move_ShouldMoveUpToTargetFloor()
    {
        var elevator = new Elevator(1);
        elevator.AddRequest(3); 

        elevator.Move();
        elevator.Move();

        Assert.AreEqual(3, elevator.CurrentFloor, "The elevator should have moved to the target floor 3.");
        Assert.IsEmpty(elevator.Requests, "The request for floor 3 should be removed after the elevator arrives.");
    }

    [Test]
    public void Move_ShouldMoveDownToTargetFloor()
    {
        var elevator = new Elevator(1);
        elevator.CurrentFloor = 5;
        elevator.Direction = Direction.Down;
        elevator.AddRequest(2);

        elevator.Move();
        elevator.Move();
        elevator.Move();

        Assert.AreEqual(2, elevator.CurrentFloor, "The elevator should have moved down to the target floor 2.");
        Assert.IsEmpty(elevator.Requests, "The request for floor 2 should be removed after the elevator arrives.");
    }

    [Test]
    public void Move_ShouldChangeDirectionWhenNoUpwardRequests()
    {
        var elevator = new Elevator(1);
        elevator.AddRequest(3);
        elevator.AddRequest(1);

        elevator.Move();
        elevator.Move();
        elevator.Move();

        Assert.AreEqual(Direction.Down, elevator.Direction, "The elevator should change direction after finishing upward requests.");
    }

    [Test]
    public void Move_ShouldNotMove_WhenNoRequests()
    {
        var elevator = new Elevator(1);
        elevator.CurrentFloor = 5;


        elevator.Move();

        Assert.AreEqual(5, elevator.CurrentFloor, "The elevator should not move if there are no requests.");
    }
}
