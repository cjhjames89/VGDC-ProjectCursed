using UnityEngine;
using System.Collections;

public class RangedAction : MonoBehaviour {
    public bool timeToFire;
    public static float speed;
    private GameObject projectile;

	// Use this for initialization
	void Start ()
    {
        timeToFire = false;
        speed = 5f;
        projectile = GameObject.Find("Projectile");
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetButtonDown("Action"))
        {
            StartCoroutine(FireProjectile());
        }
	}

    IEnumerator FireProjectile ()
    {
        timeToFire = true;

        do
        {
            Instantiate(projectile);
           
            if (Input.GetButton("Action") == false)
            {
                timeToFire = false;
            }

            yield return new WaitForSeconds(1 / speed);
        } while (timeToFire == true);
       
    }
}
