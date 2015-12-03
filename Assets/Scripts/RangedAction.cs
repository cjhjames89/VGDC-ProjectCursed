using UnityEngine;
using System.Collections;
using System;

public class RangedAction : MonoBehaviour {
    private bool timeToFire;
    public float speed;
    public GameObject projectile;
    private Transform characterTrans;
    private float fireWait = 0f;

	// Use this for initialization
	void Start ()
    {
        timeToFire = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        characterTrans = gameObject.transform;

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
            Instantiate(projectile, characterTrans.position + new Vector3(5, 0, 0), characterTrans.rotation);

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
