using UnityEngine;
using System.Collections;

public class PunchCollision : MonoBehaviour {
    public int damage;

	// Use this for initialization
	void Start ()
    {
        gameObject.transform.localPosition = new Vector3(5, 0, 0);
	}

    void OnCollisionEnter2D (Collision2D punch)
    {
        if (punch.collider.gameObject.tag == "Enemy")
        {
            Chaser.EnemyDamage(damage);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (DirectionTracking.state == 1)
        {
            gameObject.transform.localPosition = new Vector3(5, 0, 0);
        }
        else if (DirectionTracking.state == 3)
        {
            gameObject.transform.localPosition = new Vector3(-5, 0, 0);
        }
        else if (DirectionTracking.state == 4)
        {
            gameObject.transform.localPosition = new Vector3(0, 6, 0);
        }
        else if (DirectionTracking.state == 2)
        {
            gameObject.transform.localPosition = new Vector3(0, -6, 0);
        }
    }
}
