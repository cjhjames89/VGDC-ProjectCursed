using UnityEngine;
using System.Collections;

public class TestEnemy : MonoBehaviour {

    // Use this for initialization
    void Start()
    { 
        public static Transform playerObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        TestEnemy.playerObject = GameObject.FindGameObjectWithTag(Player);

        transform.LookAt(TestEnemy.playerObject);

        transform.translate(Vector3.forward*Time.deltaTime);
	}
}
