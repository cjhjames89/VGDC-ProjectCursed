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
    public Vector3 leftFistRot;
    public Vector3 rightFistRot;
    private bool right = Input.GetAxis("Horizontal") > 0 & Input.GetAxis("Vertical") == 0;
    private bool down = Input.GetAxis("Horizontal") == 0 & Input.GetAxis("Vertical") < 0;
    private bool left = Input.GetAxis("Horizontal") < 0 & Input.GetAxis("Vertical") == 0;
    private bool up = Input.GetAxis("Horizontal") == 0 & Input.GetAxis("Vertical") > 0;

    // Use this for initialization
    void Start ()
    {
        leftFist = GameObject.Find("Left Fist").transform;
        rightFist = GameObject.Find("Right Fist").transform;
        leftFistRot = new Vector3(leftFist.rotation.x, leftFist.rotation.y, leftFist.rotation.z);
        rightFistRot = new Vector3(rightFist.rotation.x, rightFist.rotation.y, rightFist.rotation.z);
    
        speed = 10f;
        punchTime = false;
        leftPunch = true;
        velocity = Vector3.zero;
        punchDelay = 0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Abs(Input.GetAxis("Vertical")))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                leftFist.localPosition = new Vector3(4, 2, 0);
                leftFist.rotation = Quaternion.FromToRotation(leftFistRot, new Vector3(0, 0, 0));
                rightFist.localPosition = new Vector3(4, -2, 0);
                rightFist.rotation = Quaternion.FromToRotation(rightFistRot, new Vector3(0, 0, 0));
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                leftFist.localPosition = new Vector3(-4, -2, 0);
                leftFist.rotation = Quaternion.FromToRotation(leftFistRot, new Vector3(0, 0, 180));
                rightFist.localPosition = new Vector3(-4, 2, 0);
                rightFist.rotation = Quaternion.FromToRotation(rightFistRot, new Vector3(0, 0, 180));

            }
        }
        else if (Mathf.Abs(Input.GetAxis("Horizontal")) < Mathf.Abs(Input.GetAxis("Vertical")))
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                leftFist.localPosition = new Vector3(2, -4, 0);
                leftFist.rotation = Quaternion.FromToRotation(leftFistRot, new Vector3(0, 0, 270));
                rightFist.localPosition = new Vector3(-2, -4, 0);
                rightFist.rotation = Quaternion.FromToRotation(rightFistRot, new Vector3(0, 0, 270));
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                leftFist.localPosition = new Vector3(-2, 4, 0);
                leftFist.rotation = Quaternion.FromToRotation(leftFistRot, new Vector3(0, 0, 90));
                rightFist.localPosition = new Vector3(2, 4, 0);
                rightFist.rotation = Quaternion.FromToRotation(rightFistRot, new Vector3(0, 0, 90));
            }
        }

        if (Input.GetButtonDown("Action") && punchDelay <= 0f)
        {
            punchDelay += (4.1f / speed);
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
            if (punchTime & leftPunch & right)
            {
                leftFist.position = new Vector3 (leftFist.position.x + 2, leftFist.position.y, leftFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftFist.position = new Vector3(leftFist.position.x - 2, leftFist.position.y, leftFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftPunch = false;
            }
            else if (punchTime & leftPunch == false & right)
            {
                rightFist.position = new Vector3(rightFist.position.x + 2, rightFist.position.y, rightFist.position.z);
                yield return new WaitForSeconds(1 / speed);
                
                rightFist.position = new Vector3(rightFist.position.x - 2, rightFist.position.y, rightFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftPunch = true;
            }
            else if (punchTime & leftPunch & down)
            {
                leftFist.position = new Vector3(leftFist.position.x, leftFist.position.y - 2, leftFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftFist.position = new Vector3(leftFist.position.x, leftFist.position.y + 2, leftFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftPunch = false;
            }
            else if (punchTime & leftPunch == false & down)
            {
                rightFist.position = new Vector3(rightFist.position.x, rightFist.position.y - 2, rightFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                rightFist.position = new Vector3(rightFist.position.x, rightFist.position.y + 2, rightFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftPunch = true;
            }
            else if (punchTime & leftPunch & left)
            {
                leftFist.position = new Vector3(leftFist.position.x - 2, leftFist.position.y, leftFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftFist.position = new Vector3(leftFist.position.x + 2, leftFist.position.y, leftFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftPunch = false;
            }
            else if (punchTime & leftPunch == false & right)
            {
                rightFist.position = new Vector3(rightFist.position.x - 2, rightFist.position.y, rightFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                rightFist.position = new Vector3(rightFist.position.x + 2, rightFist.position.y, rightFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftPunch = true;
            }
            else if (punchTime & leftPunch & up)
            {
                leftFist.position = new Vector3(leftFist.position.x, leftFist.position.y + 2, leftFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftFist.position = new Vector3(leftFist.position.x, leftFist.position.y - 2, leftFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftPunch = false;
            }
            else if (punchTime & leftPunch == false & up)
            {
                rightFist.position = new Vector3(rightFist.position.x, rightFist.position.y + 2, rightFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                rightFist.position = new Vector3(rightFist.position.x, rightFist.position.y - 2, rightFist.position.z);
                yield return new WaitForSeconds(1 / speed);

                leftPunch = true;
            }

            if (Input.GetButton("Action") == false)
            {
                punchTime = false;
            }

        } while (punchTime);
    }
}
