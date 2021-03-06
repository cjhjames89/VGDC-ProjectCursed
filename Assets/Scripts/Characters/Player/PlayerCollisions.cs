﻿using UnityEngine;
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

    void update()
    {
        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Player", "Friendly" });
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.collider.gameObject.CompareTag("Danger") & notInvincible)
        {
            CharacterHealth.takeDamage(1);
            StartCoroutine(Invincible(InvincibleTime));
        }//If player is hit by danger in first frame, start invincibility
    }

    void OnCollisionStay2D(Collision2D hit)
    {
        if (hit.collider.gameObject.CompareTag("Enemy") & notInvincible)
        { 
                CharacterHealth.takeDamage(1);
                StartCoroutine(Invincible(InvincibleTime));
        }//If player stays on enemy, do invincibility
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
    }//Starts and stops invincibility
}
