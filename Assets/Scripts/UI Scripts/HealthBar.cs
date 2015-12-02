using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public static Image healthBar;
    public int health;
    public string Tag;


    // Use this for initialization
    void Start () {
        healthBar = GameObject.FindWithTag(Tag).GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    public static void takeDamage(int damage)
    {
        float x = healthBar.transform.localScale.x - (damage * 0.099f);
        healthBar.transform.localScale = new Vector2(x, healthBar.transform.localScale.y);
    }

    public static void Invincible(int time)
    {
        
    }
}
