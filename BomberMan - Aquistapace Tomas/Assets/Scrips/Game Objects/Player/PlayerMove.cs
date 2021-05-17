using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5;
    public float moveDistance = 1;
    public float distanceRay = 1;
    
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
        //Debug.DrawRay(transform.position, Vector3.forward, Color.red);
        //Debug.DrawRay(transform.position, -Vector3.forward, Color.red);
        //Debug.DrawRay(transform.position, Vector3.right, Color.red);
        //Debug.DrawRay(transform.position, -Vector3.right, Color.red);

        MovementInput();
    }

    void MovementInput()
    {
        if (Input.GetKeyDown("up") && !CollisionChecks(Vector3.forward) && hableToMove)
        {
            StartCoroutine(MovePlayer(newUp));
        }

        if (Input.GetKeyDown("down") && !CollisionChecks(-Vector3.forward) && hableToMove)
        {
            StartCoroutine(MovePlayer(newDown));
        }

        if (Input.GetKeyDown("left") && !CollisionChecks(-Vector3.right) && hableToMove)
        {
            StartCoroutine(MovePlayer(newLeft));
        }

        if (Input.GetKeyDown("right") && !CollisionChecks(Vector3.right) && hableToMove)
        {
            StartCoroutine(MovePlayer(newRight));
        }
    }

    bool CollisionChecks(Vector3 direction)
    {
        RaycastHit hit;

        Ray collisionRay = new Ray(transform.position, direction);

        if (Physics.Raycast(collisionRay, out hit, distanceRay))
        {
            return true; // Colisiono con algo
        }
        else
        {
            return false; // No colosiono con nada
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
