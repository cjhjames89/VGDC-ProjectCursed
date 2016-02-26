using UnityEngine;
using System.Collections;

public class EnemyShield : MonoBehaviour {
    public float totalHealth;
    private float health;

    // Use this for initialization
    void Start ()
    {
        health = totalHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

        Vector3 player = GameObject.FindWithTag("Player").transform.position;
        Vector3 difference = (player - gameObject.transform.position).normalized;
        int offset = 135;

        transform.rotation = Quaternion.Euler(0, 0, PublicFunctions.FindAngle(difference.x, difference.y)+offset);

        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Enemy", "Danger" });
    }

    public void EnemyDamage(int damage)
    {
        health -= damage;
    }
}
