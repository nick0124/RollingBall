using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public Vector3 rotattion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotattion * Time.deltaTime);
	}
}
