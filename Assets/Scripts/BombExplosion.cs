using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour {
    public float range;
    public int damage;

	// Use this for initialization
	void Start ()
    {
        gameObject.transform.localScale = new Vector3(range, range * 2 / 3, 1);
	}
	
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.collider.gameObject.tag == "Enemy")
        {
            Chaser.EnemyDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] friendlies = GameObject.FindGameObjectsWithTag("Friendly");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject col in friendlies)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), col.GetComponent<Collider2D>());
        }

        foreach (GameObject col in players)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), col.GetComponent<Collider2D>());
        }
    }
}
