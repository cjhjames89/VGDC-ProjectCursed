using UnityEngine;
using System.Collections;

public class ProjectileAction : MonoBehaviour {
    public float speed;
    public static int damage;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, 3);
    }
	
    void OnCollision2D(Collision2D contact)
    {
        if (contact.collider.gameObject.tag == "Enemy")
        {
            Chaser.EnemyDamage(damage);
        }

        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
	}
}
