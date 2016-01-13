using UnityEngine;
using System.Collections;

public class ProjectileAction : MonoBehaviour {
    public float speed;
    public int damage;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, 3);

        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Player", "Friendly" });
    }
	
    void OnCollisionEnter2D(Collision2D contact)
    {
        PublicFunctions.DamageEnemy(contact, damage);

        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);

        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Player", "Friendly" });
    }
}
