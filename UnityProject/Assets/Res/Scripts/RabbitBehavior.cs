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
        targetPos = waypoints[Random.Range(0, waypoints.Length)];
    }

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, targetPos.transform.position, 0.005f);

        if(transform.position == targetPos.transform.position) {
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
