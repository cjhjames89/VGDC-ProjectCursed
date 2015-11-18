using UnityEngine;
using System.Collections;

public class BrawlerAction : MonoBehaviour {

    public Transform leftFist;
    public Transform rightFist;
    public static float speed;
    private bool punchTime;
    private bool leftPunch;
    public Vector3 velocity;

	// Use this for initialization
	void Start ()
    {
        leftFist = GameObject.Find("Left Fist").transform;
        rightFist = GameObject.Find("Right Fist").transform;
        speed = 5;
        punchTime = false;
        leftPunch = true;
        velocity = Vector3.Zero;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetButtonDown("Action"))
        {
            StartCoroutine(DoPunch());
        }
	}

    IEnumerator DoPunch ()
    {
        do
        {
            punchTime = true;
            if (punchTime && leftPunch)
            {
                leftFist.position = Vector3.SmoothDamp(leftFist.position, leftFist.position + new Vector3(1, 0, 0), ref velocity, 1 / speed);
                rightFist.position = Vector3.SmoothDamp(rightFist.position, leftFist.position - new Vector3(1, 0, 0), ref velocity, 1 / speed);
                yield return new WaitForSeconds(1 / speed);

                leftFist.position = Vector3.SmoothDamp(leftFist.position, leftFist.position - new Vector3(1, 0, 0), ref velocity, 1 / speed);
                rightFist.position = Vector3.SmoothDamp(rightFist.position, leftFist.position + new Vector3(1, 0, 0), ref velocity, 1 / speed);
                yield return new WaitForSeconds(1 / speed);

                leftPunch = false;
            }

            else if (punchTime && leftPunch == false)
            {
                leftFist.position = Vector3.SmoothDamp(leftFist.position, leftFist.position - new Vector3(1, 0, 0), ref velocity, 1 / speed);
                rightFist.position = Vector3.SmoothDamp(rightFist.position, leftFist.position + new Vector3(1, 0, 0), ref velocity, 1 / speed);
                yield return new WaitForSeconds(1 / speed);

                leftFist.position = Vector3.SmoothDamp(leftFist.position, leftFist.position + new Vector3(1, 0, 0), ref velocity, 1 / speed);
                rightFist.position = Vector3.SmoothDamp(rightFist.position, leftFist.position - new Vector3(1, 0, 0), ref velocity, 1 / speed);
                yield return new WaitForSeconds(1 / speed);

                leftPunch = true;
                if (Input.GetButton("Action") = false)
                {
                    punchTime = false;
                }
            }
        } while (punchTime);
    }
}
