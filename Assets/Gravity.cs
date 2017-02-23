using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

    [Range(-1, 1)]
    public float x;
    [Range(-1, 1)]
    public float y;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        Physics.gravity = new Vector3(x * 9.8f, -9.8f, y * 9.8f);
    }
}
