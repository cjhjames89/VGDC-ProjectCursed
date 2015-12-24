using UnityEngine;
using System.Collections;

public class Healthbar : MonoBehaviour {
	GameObject camera1;
	// Use this for initialization
	void Start () {
	
		camera1 = GameObject.Find ("Main Camera");

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.LookAt(camera1.transform);

	}
}
