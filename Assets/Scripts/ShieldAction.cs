using UnityEngine;
using System.Collections;

public class ShieldAction : MonoBehaviour {
    public CircleCollider2D outerShield;
    public static int team = 5;

	// Use this for initialization
	void Start ()
    {
        outerShield = gameObject.GetComponent<CircleCollider2D>();
	}
	
    void OnColliderEnter(Collider other)
    {
        //Destroy enemy projectiles
    }


	// Update is called once per frame
	void Update ()
    {
        GameObject.Destroy(gameObject, 5);
	}
}

//Possibly make shield for enemies as well?