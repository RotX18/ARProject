using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBehavior : MonoBehaviour
{
    //PUBLIC VARS
    public Animator anim;
    public GameObject[] waypoints;

    //PRIVATE VARS
    //floats
    private float _moveSpeed = 0.003f;

    //bools
    private bool _executeCoroutines = true;
    private bool _move = true;

    //GameObjects
    private GameObject _targetPos;

    private void Start() {
        //at Start, select a random waypoint to move toward
        _targetPos = waypoints[Random.Range(0, waypoints.Length)];
    }

    private void Update() {
        //changing the position to the target position using Vector3.MoveTowards();
        if(_move){
            transform.position = Vector3.MoveTowards(transform.position, _targetPos.transform.position, _moveSpeed);
            transform.LookAt(_targetPos.transform);
        }

        if(transform.position == _targetPos.transform.position) {
            //once rabbit has reached the target waypoint check whether it should stay in place for a few seconds
            if(_executeCoroutines == true){
                _move = false;
                _executeCoroutines = false;
                StartCoroutine(goIdle());
            }
            else{
                SetNewTarget();
            }
        }
    }

    private void SetNewTarget() {
        GameObject newTarget = waypoints[Random.Range(0, waypoints.Length)];

        if(_targetPos.transform.position == newTarget.transform.position) {
            //rerolling if the new position is the same as the current position
            _targetPos = waypoints[Random.Range(0, waypoints.Length)];
        }
        else {
            _targetPos = newTarget;
        }
    }

    private IEnumerator goIdle(){
        //coroutine to set the animator to idle state for a random amt of seconds before reverting
        anim.SetBool("IdleState", true);
        yield return new WaitForSeconds(Random.Range(3, 7));
        anim.SetBool("IdleState", false);

        //allowing this coroutine to be executed again
        _executeCoroutines = true;

        //setting new target and allowing the rabbit to move
        SetNewTarget();
        _move = true;
    }
}
