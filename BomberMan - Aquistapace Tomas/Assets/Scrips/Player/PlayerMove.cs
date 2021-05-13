using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5;
    public float moveDistance = 1;

    public bool hableToMove;

    private Vector3 newUp;
    private Vector3 newDown;
    private Vector3 newRight;
    private Vector3 newLeft;

    void Start()
    {
        newUp = new Vector3(0, 0, moveDistance);
        newDown = new Vector3(0, 0, -moveDistance);
        newRight = new Vector3(moveDistance, 0, 0);
        newLeft = new Vector3(-moveDistance, 0, 0);

        hableToMove = true;
    }

    void Update()
    {

        MovementInput();

    }

    void MovementInput()
    {
        if (Input.GetKeyDown("up") && hableToMove)
        {
            StartCoroutine(MovePlayer(newUp));
        }
        if (Input.GetKeyDown("down") && hableToMove)
        {
            StartCoroutine(MovePlayer(newDown));
        }
        if (Input.GetKeyDown("left") && hableToMove)
        {
            StartCoroutine(MovePlayer(newLeft));
        }
        if (Input.GetKeyDown("right") && hableToMove)
        {
            StartCoroutine(MovePlayer(newRight));
        }
    }

    IEnumerator MovePlayer(Vector3 addPos)
    {
        float time = 0;
        hableToMove = false;

        Vector3 newPosition = transform.position + addPos;

        while (time <= 1)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, time);

            time += moveSpeed * Time.deltaTime;
            yield return null;
        }

        hableToMove = true;

        yield return true;
    }
}
