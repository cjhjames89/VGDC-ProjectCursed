using UnityEngine;
using System.Collections;

public class ShooterDirection : MonoBehaviour {
    public static int state;

	// Use this for initialization
	void Start ()
    {
        state = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 difference = GameObject.FindWithTag("Player").transform.position - gameObject.transform.position;

        if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y) & difference.x > 0)
        {
            state = 1;
        }
        else if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y) & difference.x < 0)
        {
            state = 3;
        }
        else if (Mathf.Abs(difference.x) < Mathf.Abs(difference.y) & difference.y > 0)
        {
            state = 4;
        }
        else if (Mathf.Abs(difference.x) < Mathf.Abs(difference.y) & difference.y < 0)
        {
            state = 2;
        }
    }
}
