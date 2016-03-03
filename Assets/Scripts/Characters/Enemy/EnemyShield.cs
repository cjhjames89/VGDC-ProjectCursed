using UnityEngine;
using System.Collections;

public class EnemyShield : MonoBehaviour {
    public float totalHealth;
    private float health;
    public GameObject master;

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
        //Compensates for angle offset

        transform.position = master.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, PublicFunctions.FindAngle(difference.x, difference.y)+offset);
        //Sets rotation to face player in 2D

        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Enemy", "Danger" });
        //Phase through objects labeled as enemies or dangerous
    }

    public void EnemyDamage(int damage)
    {
        health -= damage;
    }//Be damaged if hit
}
