using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	public int speed = 24;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate(Vector3.forward * speed * Time.deltaTime);
		transform.Translate(Vector3.left * speed/150 * Time.deltaTime);
	}
}
