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
        Transform player = GameObject.FindWithTag("Player").transform;
        Transform target = player;
        Vector3 targetPos = target.position;
        targetPos.z = gameObject.transform.position.z;
        target.position = targetPos;

        transform.LookAt(target);

        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Enemy", "Danger" });
    }

    public void EnemyDamage(int damage)
    {
        health -= damage;
    }
}
