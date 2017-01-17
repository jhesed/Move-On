using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour {

	public GameObject platform; // reference to the platform to move

	public GameObject[] myWaypoints; // array of all the waypoints

	[Range(0.0f, 10.0f)] // create a slider in the editor and set limits on moveSpeed
	public float moveSpeed = 5f; // enemy move speed
	public float waitAtWaypointTime = 1f; // how long to wait at a waypoint before _moving to next waypoint

	public bool loop = true; // should it loop through the waypoints

	// private variables

	Transform _transform;
	int _myWaypointIndex = 0;		// used as index for My_Waypoints

    // Use this for initialization
    void Start () {
		_transform = platform.transform;
	}
	
	// game loop
	void Update () {
		// if beyond _moveTime, then start moving
	    Movement();
	}

	void Movement() {
  
        _transform.position = Vector3.MoveTowards(_transform.position, _transform.position + new Vector3(100, 0, 0), moveSpeed * Time.deltaTime);
			
	}
}
