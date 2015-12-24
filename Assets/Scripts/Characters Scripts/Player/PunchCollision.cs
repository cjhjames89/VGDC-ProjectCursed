using UnityEngine;
using System.Collections;

public class PunchCollision : MonoBehaviour {
    public int damage;

	// Use this for initialization
	void Start ()
    {
        transform.localPosition = new Vector3(5, 0, 0);
	}

    void OnCollisionEnter2D (Collision2D punch)
    {
        PublicFunctions.DamageEnemy(punch, damage);
    }
	
	// Update is called once per frame
	void Update ()
    { 
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localPosition = new Vector3(5, 0, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localPosition = new Vector3(-5, 0, 0);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            transform.localPosition = new Vector3(0, 6, 0);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            transform.localPosition = new Vector3(0, -6, 0);
        }
    }
}
