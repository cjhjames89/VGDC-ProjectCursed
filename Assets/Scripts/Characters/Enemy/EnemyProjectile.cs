using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {
    public float speed;
    public int damage;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 3);

        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Enemy", "Danger" });
        //Phase through objects as enemies and dangerous
    }

    void OnCollisionEnter2D(Collision2D contact)
    {
        if (contact.collider.gameObject.tag != "Enemy" & contact.collider.gameObject.tag != "Danger")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);

        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Enemy", "Danger" });
        //Phase through objects as enemies and dangerous
    }
}
