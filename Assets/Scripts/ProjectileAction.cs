using UnityEngine;
using System.Collections;

public class ProjectileAction : MonoBehaviour {
    public static float speed;
    private BoxCollider2D projCollider;
    public static int team = 2;

	// Use this for initialization
	void Start ()
    {
        speed = 5f;
        projCollider = gameObject.GetComponent<BoxCollider2D>();
        GameObject.Destroy(gameObject, 3);
    }
	
    void OnColliderEnter(Collider other)
    {
        //Give Damage to enemy.
    }

	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * speed);
	}
}
