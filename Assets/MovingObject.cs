using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

    public Transform movingObject;
    public Transform position1;
    public Transform position2;
    public Vector3 newPosition;
    public string currentState;
    public float smooth;
    public float resetTime;

    //переделать на свой скрипт

	// Use this for initialization
	void Start () {
        ChangeTarget();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        movingObject.position = Vector3.Lerp(movingObject.position, newPosition, smooth * Time.deltaTime);
	}

    void ChangeTarget()
    {
        if(currentState == "MoveToPos1")
        {
            currentState = "MoveToPos2";
            newPosition = position2.position;
        }
        else if(currentState == "MoveToPos2")
        {
            currentState = "MoveToPos1";
            newPosition = position1.position;
        }
        else if(currentState == "")
        {
            currentState = "MoveToPos2";
            newPosition = position2.position;
        }
        Invoke("ChangeTarget", resetTime);
    }
}
