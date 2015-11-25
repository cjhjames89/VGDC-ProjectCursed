using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public static Image healthBar;
    public static int enemyHealth;


    // Use this for initialization
    void Start()
    {
        healthBar = GameObject.FindWithTag("EHealth").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void takeDamage(int damage)
    {
        float x = healthBar.transform.localScale.x - (damage * 0.099f);
        healthBar.transform.localScale = new Vector2(x, healthBar.transform.localScale.y);
    }
}