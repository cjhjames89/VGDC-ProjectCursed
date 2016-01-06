using UnityEngine;
using System.Collections;

public class ShieldAction : MonoBehaviour {
    public int damage;
    public float size;

	// Use this for initialization
	void Start ()
    {
        gameObject.transform.localScale = new Vector3(size, size, size);
	}

    void OnCollisionEnter2D(Collision2D touch)
    {
        PublicFunctions.DamageEnemy(touch, damage);
    }

	// Update is called once per frame
	void Update ()
    {
        PublicFunctions.PhaseThruPlayer(gameObject);

        transform.localPosition = Vector3.zero;
	}
}

//Possibly make shield for enemies as well?