using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

  
    public float movementSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var inputVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        transform.Translate(inputVector*movementSpeed*Time.deltaTime);

    }
}
