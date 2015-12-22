using UnityEngine;
using System.Collections;
using System;

public class RangedAction : MonoBehaviour {
    private bool timeToFire;
    public float speed;
    public GameObject projectile;
    private Transform characterTrans;
    private float fireWait = 0f;
    public float cost;

	// Use this for initialization
	void Start ()
    {
        timeToFire = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        characterTrans = gameObject.transform;

        characterTrans.localPosition = Vector3.zero;

        if (fireWait > 0)
        {
            fireWait -= Time.deltaTime;
        }

	    if (Input.GetButton("Action") & fireWait <= 0)
        {
            FireProjectile();
            fireWait += 1.2f / speed;
        }
	}

    void FireProjectile ()
    {
        if (DirectionTracking.state == 1)
        {
            Instantiate(projectile, characterTrans.position + new Vector3(5, 0, 0), characterTrans.rotation);
        }
        else if (DirectionTracking.state == 3)
        {
            Instantiate(projectile, characterTrans.position + new Vector3(-5, 0, 0), Quaternion.Euler(0, 0, 180));
        }
        else if (DirectionTracking.state == 4)
        {
            Instantiate(projectile, characterTrans.position + new Vector3(0, 5, 0), Quaternion.Euler(0, 0, 90));
        }
        else if (DirectionTracking.state == 2)
        {
            Instantiate(projectile, characterTrans.position + new Vector3(0, -5, 0), Quaternion.Euler(0, 0, 270));
        }

        if (Input.GetButton("Action") == false)
        {
            timeToFire = false;
        }

        StartCoroutine(PublicFunctions.InstantDrain(cost));
    }

    private void Instantiate(GameObject projectile, Vector3 vector3)
    {
        throw new NotImplementedException();
    }
}
