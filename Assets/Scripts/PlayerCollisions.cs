using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.collider.gameObject.tag == "Enemy" | hit.collider.gameObject.tag == "Danger")
        {
            print("Collided");
            CharacterHealth.takeDamage(1);
        }
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
}
