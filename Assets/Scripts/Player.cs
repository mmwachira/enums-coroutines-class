using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float moveDistance = 4f;
    private Vector3 startPosition;
    private MovementDirection currentDirection;
    private MovementDirection newDirection;
    private bool directionChanged = false;
    public TMP_Text directionText;

    void Start()
    {
        startPosition = transform.position;
        currentDirection = MovementDirection.Right;
        newDirection = currentDirection;
        StartCoroutine(move());
    }

    public void SetNewDirection(MovementDirection direction)
    {
        newDirection = direction;
        directionChanged = true;
    }

    public IEnumerator move()
    {
        while (true)
        {
            Vector3 targetPosition = GetTargetPosition(currentDirection);


            directionText.text = currentDirection.ToString();
            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
            transform.position = targetPosition;

            yield return new WaitForSeconds(0.5f);


            while (Vector3.Distance(transform.position, startPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
            transform.position = startPosition;

            if (directionChanged)
            {
                currentDirection = newDirection;
                directionChanged = false;
            }
        }
    }

    private Vector3 GetTargetPosition(MovementDirection direction)
    {
        switch (direction)
        {
            case MovementDirection.Up: return startPosition + Vector3.up * moveDistance;
            case MovementDirection.Down: return startPosition + Vector3.down * moveDistance;
            case MovementDirection.Left: return startPosition + Vector3.left * moveDistance;
            case MovementDirection.Right: return startPosition + Vector3.right * moveDistance;
            default: return startPosition;
        }
    }


}