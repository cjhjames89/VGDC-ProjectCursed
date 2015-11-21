using UnityEngine;
using System.Collections;

public class BrawlerAction : MonoBehaviour {

    public Transform leftFist;
    public Transform rightFist;
    public static float speed;
    private bool punchTime;
    private bool leftPunch;
    public Vector3 velocity;
    private float punchDelay;
    public static int team = 1;

	// Use this for initialization
	void Start ()
    {
        leftFist = GameObject.Find("Left Fist").transform;
        rightFist = GameObject.Find("Right Fist").transform;
        speed = 10f;
        punchTime = false;
        leftPunch = true;
        velocity = Vector3.zero;
        punchDelay = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetButtonDown("Action") && punchDelay <= 0f)
        {
            StartCoroutine(DoPunch());
            punchDelay += (4 / speed);
        }

        if (punchDelay > 0)
        {
            punchDelay += -Time.deltaTime;
        }
	}

    IEnumerator DoPunch ()
    {
        do
        {
            punchTime = true;
            if (punchTime && leftPunch)
            {
                leftFist.position = new Vector3 (leftFist.position.x + 2, leftFist.position.y, leftFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftFist.position = new Vector3(leftFist.position.x - 2, leftFist.position.y, leftFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftPunch = false;
            }
            else if (punchTime && leftPunch == false)
            {
                rightFist.position = new Vector3(rightFist.position.x + 2, rightFist.position.y, rightFist.position.z);
                yield return new WaitForSeconds(1 / speed);
                
                rightFist.position = new Vector3(rightFist.position.x - 2, rightFist.position.y, rightFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftPunch = true;

                if (Input.GetButton("Action") == false)
                {
                    punchTime = false;
                }
            }
        } while (punchTime);
    }
}
