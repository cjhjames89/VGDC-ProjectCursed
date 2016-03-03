using UnityEngine;
using System.Collections;

public class PunchCollision : MonoBehaviour {
    public int damage;

    // Use this for initialization
    void Start()
    {
        transform.localPosition = new Vector3(5, 0, 0);
    }

    void OnCollisionEnter2D (Collision2D punch)
    {
        PublicFunctions.DamageEnemy(punch, damage);
    }//Damage enemy if a punch is hit
	
	// Update is called once per frame
	void Update ()
    { 
        if (DirectionTracking.state == 1)
        {
            transform.localPosition = new Vector3(5, 0, 0);
        }
        else if (DirectionTracking.state == 3)
        {
            transform.localPosition = new Vector3(-5, 0, 0);
        }
        else if (DirectionTracking.state == 4)
        {
            transform.localPosition = new Vector3(0, 6, 0);
        }
        else if (DirectionTracking.state == 2)
        {
            transform.localPosition = new Vector3(0, -6, 0);
        }//Tracks the state to place the fist
    }
}
