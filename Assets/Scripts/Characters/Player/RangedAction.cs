using UnityEngine;
using System.Collections;
using System;

public class RangedAction : MonoBehaviour {
    public float speed;
    public GameObject projectile;
    private Transform characterTrans;
    private float fireWait = 0f;
    public float cost;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        characterTrans = gameObject.transform;

        characterTrans.localPosition = Vector3.zero;

        if (fireWait > 0)
        {
            fireWait -= Time.deltaTime;
        }//Recharge the fire time

	    if (Input.GetButton("Action") & fireWait <= 0)
        {
            FireProjectile();
            fireWait += 1.2f / speed;
        }//If button is pressed and firing is ready, fire projectile
	}

    void FireProjectile ()
    {
        if (DirectionTracking.state == 1)
        {
            Instantiate(projectile, characterTrans.position + new Vector3(5, 0, 0), Quaternion.Euler(0, 0, 0));
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
        }//Tracks direction to fire the projectile

        StartCoroutine(PublicFunctions.InstantDrain(cost));
        //Drains the mana bar
    }

    private void Instantiate(GameObject projectile, Vector3 vector3)
    {
        throw new NotImplementedException();
    }
}
