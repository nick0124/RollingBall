using UnityEngine;
using System.Collections;

public class PlayerTest : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movementArrows = new Vector3(moveHorizontal, 0, moveVertical); 
        GetComponent<Rigidbody>().AddForce(movementArrows * 20);
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.tag=="Dangerous")
        {
            Destroy(gameObject);
        }
    }
}
