using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {
    private bool notInvincible;
    public float InvincibleTime;
    public static SpriteRenderer sprite;

	// Use this for initialization
	void Start ()
    {
        notInvincible = true;
	}

    void OnCollisionStay2D(Collision2D hit)
    {
        if (hit.collider.gameObject.tag == "Enemy" | hit.collider.gameObject.tag == "Danger")
        {
            if (notInvincible)
            {
                CharacterHealth.takeDamage(1);
                StartCoroutine(Invincible(InvincibleTime));
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    IEnumerator Invincible(float time)
    {
        notInvincible = false;
        sprite.color = Color.gray;

        yield return new WaitForSeconds(time);

        notInvincible = true;
        sprite.color = Color.white;
    }
}
