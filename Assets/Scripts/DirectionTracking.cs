using UnityEngine;
using System.Collections;

public class DirectionTracking : MonoBehaviour {
    public static int state;

	// Use this for initialization
	void Start ()
    {
        state = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetAxis("Horizontal") > 0)
        {
            state = 1;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            state = 3;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            state = 4;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            state = 2;
        }
	}
}
