using UnityEngine;
using System.Collections;

public class BombAction : MonoBehaviour {
    public float armTime;
    public float range;
    public float duration;
    public GameObject explosion;
    public CircleCollider2D detection;

	// Use this for initialization
	void Start ()
    {
        detection.enabled = false;
        explosion.SetActive(false);
        Destroy(gameObject, duration);
	}

    void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.CompareTag("Enemy") | enemy.gameObject.CompareTag("Danger"))
        {
            StartCoroutine(Explode());
        }//If a bomb comes in contact with enemy or dangerous object, explode
    }

	// Update is called once per frame
	void Update ()
    {
        armTime -= Time.deltaTime;

        if (armTime <= 0)
        {
            detection.enabled = true;
            detection.radius = range;
        }//Arm the bomb, until this time the bomb won't explode

        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Player", "Friendly" });
        //Phase through friendly and player objects.
	}

    IEnumerator Explode()
    {
        explosion.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }//Turn on explosion object, then destroy
}
