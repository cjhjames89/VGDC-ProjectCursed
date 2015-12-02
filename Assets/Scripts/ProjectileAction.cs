using UnityEngine;
using System.Collections;

public class ProjectileAction : MonoBehaviour {
    public float speed;
    private BoxCollider2D projCollider;

	// Use this for initialization
	void Start ()
    {
        projCollider = gameObject.GetComponent<BoxCollider2D>();
        GameObject.Destroy(gameObject, 3);
    }
	
    void OnCollisionEnter2D(Collision2D other)
    {
        //Give Damage to enemy.
    }

	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
	}
}
