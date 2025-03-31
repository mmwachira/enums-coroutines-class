using UnityEngine;
using System.Collections;

public enum MovementDirection
{
    Up,
    Down,
    Left,
    Right
}

public class Direction : MonoBehaviour
{
    public MovementDirection _movementdirection;
    public Player player;


    public void SetDirectionUp() => player.SetNewDirection(MovementDirection.Up);
    public void SetDirectionDown() => player.SetNewDirection(MovementDirection.Down);
    public void SetDirectionLeft() => player.SetNewDirection(MovementDirection.Left);
    public void SetDirectionRight() => player.SetNewDirection(MovementDirection.Right);
}
