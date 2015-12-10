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

	    if (Input.GetButtonDown("Action") & fireWait <= 0)
        {
            StartCoroutine(FireProjectile());
            fireWait += 1.2f / speed;
        }
	}

    IEnumerator FireProjectile ()
    {
        timeToFire = true;

        do
        {
            if (DirectionTracking.state == 1)
            {
                Instantiate(projectile, characterTrans.position + new Vector3(5, 0, 0), characterTrans.rotation);
            }
            else if (DirectionTracking.state == 3)
            {
                Instantiate(projectile, characterTrans.position + new Vector3(-5, 0, 0), characterTrans.rotation);
            }
            else if (DirectionTracking.state == 4)
            {
                Instantiate(projectile, characterTrans.position + new Vector3(0, 5, 0), characterTrans.rotation);
            }
            else if (DirectionTracking.state == 2)
            {
                Instantiate(projectile, characterTrans.position + new Vector3(0, -5, 0), characterTrans.rotation);
            }

            StartCoroutine(PublicFunctions.InstantDrain(cost));

            yield return new WaitForSeconds(1 / (speed * 2));

            if (Input.GetButton("Action") == false)
            {
                timeToFire = false;
            }

            yield return new WaitForSeconds(1 / (speed * 2));

        } while (timeToFire);
       
    }

    private void Instantiate(GameObject projectile, Vector3 vector3)
    {
        throw new NotImplementedException();
    }
}
