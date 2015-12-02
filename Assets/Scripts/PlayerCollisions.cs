using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D hit)
    {
        print("Collided");
        if (hit.collider.gameObject.tag == "Enemy" | hit.collider.gameObject.tag == "Danger")
        {
            HealthBar.takeDamage(1);
        }
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
}
