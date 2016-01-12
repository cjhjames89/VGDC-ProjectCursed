using UnityEngine;
using System.Collections;

public class ShieldAction : MonoBehaviour {
    public int damage;
    public float size;
    private CircleCollider2D outer;

	// Use this for initialization
	void Start ()
    {
        outer = gameObject.GetComponent<CircleCollider2D>();

        gameObject.transform.localScale = new Vector3(size * 3 / 4, size, size);
        PublicFunctions.PhaseThruPlayer(gameObject);
        PublicFunctions.PhaseThruEnemy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D touch)
    {
        PublicFunctions.DamageEnemy(touch, damage);
    }

	// Update is called once per frame
	void Update ()
    {
        PublicFunctions.PhaseThruPlayer(gameObject);
        PublicFunctions.PhaseThruEnemy(gameObject);

        transform.localPosition = Vector3.zero;
	}
}

//Possibly make shield for enemies as well?