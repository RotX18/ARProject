using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBehavior : MonoBehaviour
{
    //PUBLIC VARS
    public GameObject[] waypoints;

    //PRIVATE VARS
    private GameObject targetPos;

    private void Start() {
        //at Start, select a random waypoint to move toward
        targetPos = waypoints[Random.Range(0, waypoints.Length)];
    }

    private void Update() {
        //changing the position to the target position using Vector3.MoveTowards();
        transform.position = Vector3.MoveTowards(transform.position, targetPos.transform.position, 0.005f);

        if(transform.position == targetPos.transform.position) {
            //once rabbit has reached the target waypoint, change the target position so that it can move toward the new target
            SetNewTarget();
        }
    }

    private void SetNewTarget() {
        GameObject newTarget = waypoints[Random.Range(0, waypoints.Length)];

        if(targetPos.transform.position == newTarget.transform.position) {
            //rerolling if the new position is the same as the current position
            targetPos = waypoints[Random.Range(0, waypoints.Length)];
        }
        else {
            targetPos = newTarget;
        }
    }
}
