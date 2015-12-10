using UnityEngine;
using System.Collections;

public class ProjectileAction : MonoBehaviour {
    public float speed;
    public int damage;
    private int startState;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, 3);
        startState = DirectionTracking.state;
    }
	
    void OnCollisionEnter2D(Collision2D contact)
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
        if (startState == 1)
        {
            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }
        else if (startState == 3)
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }
        else if (startState == 4)
        {
            transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        }
        else if (startState == 2)
        {
            transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
        }
    }
}
