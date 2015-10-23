using UnityEngine;
using System.Collections;

public class Spark : MonoBehaviour {
	bool timeToSwitch;

	// Use this for initialization
	void Start () {
		StartCoroutine(Switching());
		Destroy(gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(timeToSwitch)
		{
			transform.Translate(Vector3.up * Time.deltaTime);
		}
		else
		{
			transform.Translate(Vector3.down * Time.deltaTime);
		}

	}

	IEnumerator Switching ()
	{
		timeToSwitch = false;
		yield return new WaitForSeconds(1);
		timeToSwitch = true;
		yield return new WaitForSeconds(1);
		StartCoroutine(Switching());
	}
}
