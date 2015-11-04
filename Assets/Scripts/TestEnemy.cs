using UnityEngine;
using System.Collections;

public class TestEnemy : MonoBehaviour {

    public static GameObject playerObject;
    public float speed;

    // Use this for initialization
    void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(playerObject.transform);
        var movementVector = new Vector3(0.0f, 0.0f, 1);

        transform.Translate(movementVector*Time.deltaTime*speed);
	}
}
