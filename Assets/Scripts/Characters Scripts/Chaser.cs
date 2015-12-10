using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour {

    public float totalHealth;
    public static float health;
    public float speed;
    public static Transform player;
    public GameObject healthBar;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        healthBar.SetActive(false);

        health = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.localScale = new Vector3(2 * health / totalHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        Vector3 direction1 = new Vector3(player.position.x - gameObject.transform.position.x, player.position.y - gameObject.transform.position.y, 0);

        Vector3 move = direction1;

        Vector3 direction2 = new Vector3(-direction1.x, direction1.y, direction1.z);

        direction1.Normalize();
        direction2.Normalize();

        if (move.x < 0)
        {
            transform.LookAt(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1));

            transform.Translate(direction2 * Time.deltaTime * speed);
        }
        else if (move.x > 0)
        {
            transform.LookAt(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1));

            transform.Translate(direction1 * Time.deltaTime * speed);
        }

        if (health != totalHealth)
        {
            healthBar.SetActive(true);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

	}

    public static void EnemyDamage(int damage)
    {
        health -= damage;
    }
}
