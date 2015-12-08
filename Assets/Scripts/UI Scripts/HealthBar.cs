using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public static Image healthBar;
    public string Tag;
    public static float invincibleTime;
    private GameObject player;
    public GameObject gameOver;

    // Use this for initialization
    void Start ()
    {
        healthBar = GameObject.FindWithTag(Tag).GetComponent<Image>();
        invincibleTime = 3;
        player = GameObject.FindGameObjectWithTag("Player");
        gameOver.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (CharacterHealth.health <= 0.1f)
        {
            Destroy(player);
            gameOver.SetActive(true);
        }

        float x = CharacterHealth.health / CharacterHealth.totalHealth;

        healthBar.transform.localScale = new Vector2(x, healthBar.transform.localScale.y);
	}


}
