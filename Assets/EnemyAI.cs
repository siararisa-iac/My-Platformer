using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyState { Patrol, Chase}
    [SerializeField] private EnemyState currentState;

    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private Transform player;
    private Transform targetTransform;
    private float moveSpeed = 3.0f;

    [SerializeField] float distanceFromPlayer;
    private bool enteredPatrol = false;
    //Transitions
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector2.Distance(transform.position, player.position);
        //simple FSM (finite state machine)
        switch (currentState)
        {
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Chase:
                Chase();
                break;
        }
    }

    private void Patrol()
    {
        //behavior
        if (!enteredPatrol)
        {
            SetWaypoint();
            enteredPatrol = true;
        }

        // Move to the target until we reach the distance
        if (Vector3.Distance(transform.position, targetTransform.position) > 0.1f)
        {
            MoveToWaypoint();
        }
        else
        {
            //Once reached, then assign a new waypoint
            SetWaypoint();
        }

        //transition from patrol to chase
        if (distanceFromPlayer < 1.0f)
        {
            currentState = EnemyState.Chase;
            enteredPatrol = false;
        }
    }

    void Chase()
    {
        //behavior
        targetTransform = player;
        transform.position = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * moveSpeed);

        // transition from chase to patrol
        if (distanceFromPlayer > 1.0f)
        {
            currentState = EnemyState.Patrol;
        }
    }

    void SetWaypoint()
    {
        //Get a random waypoint from the array
        targetTransform = wayPoints[Random.Range(0, wayPoints.Length)];
    }

    void MoveToWaypoint()
    {
        transform.position = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * moveSpeed);
    }
}
