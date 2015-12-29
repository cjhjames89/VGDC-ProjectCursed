using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {
    public int gain;
    public float stay;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, stay);
        PublicFunctions.PhaseThruEnemy(gameObject);
        PublicFunctions.PhaseThruFriend(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
        PublicFunctions.PhaseThruEnemy(gameObject);
        PublicFunctions.PhaseThruFriend(gameObject);
	}

    void OnCollisionEnter2D(Collision2D PickUp)
    {
        if (PickUp.gameObject.CompareTag("Player"))
        {
            if(CharacterHealth.health < CharacterHealth.totalHealth - gain)
            {
                CharacterHealth.takeDamage(-gain);
            }
            else
            {
                CharacterHealth.health = CharacterHealth.totalHealth;
            }
        }

        Destroy(gameObject);
    }
}
