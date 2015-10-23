using UnityEngine;
using System.Collections;

public class HitWave : MonoBehaviour {
	int speed = 55;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
