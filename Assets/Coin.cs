using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    [Range(0,360)]
    public float x;
    [Range(0, 360)]
    public float y;
    [Range(0, 360)]
    public float z;

    public GameObject start;
    public GameObject end;

    Vector3 startPos;
    Vector3 endPos;

    [Range(0, 10)]
    public float speed;
    //public float startPos;
    //public float endPos;

	// Use this for initialization
	void Start () {
        startPos = start.transform.position;
        endPos = end.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
        transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * speed);
	}
}
