using UnityEngine;
using System.Collections;

public class PunchCollision : MonoBehaviour {
    public int damage;

	// Use this for initialization
	void Start ()
    {

	}

    void OnCollisionEnter2D (Collision2D punch)
    {
        if (punch.collider.gameObject.tag == "Enemy")
        {
            //Chaser.EnemyDamage(damage);
            Chaser c = (Chaser) punch.collider.gameObject.GetComponent(typeof(Chaser));
            c.EnemyDamage(damage);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

	}
}
