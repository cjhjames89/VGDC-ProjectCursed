using UnityEngine;
using System.Collections;

public class CharacterHealth : MonoBehaviour {
    public int AtotalHealth;
    public static float health;
    public static int totalHealth;

	// Use this for initialization
	void Start ()
    {
        totalHealth = AtotalHealth;
        health = totalHealth;
	}//Set health to total health
	
	// Update is called once per frame
	void Update ()
    {

	}

    public static void takeDamage(int damage)
    {
        health -= damage * 0.999f;
    }
}
