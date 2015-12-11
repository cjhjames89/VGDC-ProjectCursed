using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
    public float totalHealth;
    private float health;
    public float speed;
    private Transform player;
    public GameObject healthBar;
    public float range;
    public GameObject projectile;
    public float rate;
    private float fireTime;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        healthBar.SetActive(false);

        health = totalHealth;

        fireTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float difference = (player.position - gameObject.transform.position).magnitude;

        if (fireTime > 0)
        {
            fireTime -= Time.deltaTime;
        }

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

        if (difference <= range & fireTime <= 0)
        {
            if (ShooterDirection.state == 1)
            {
                Instantiate(projectile, gameObject.transform.position + new Vector3(7, 0, 0), Quaternion.Euler(0, 0, 0));
            }
            else if (ShooterDirection.state == 3)
            {
                Instantiate(projectile, gameObject.transform.position + new Vector3(-7, 0, 0), Quaternion.Euler(0, 0, 180));
            }
            else if (ShooterDirection.state == 4)
            {
                Instantiate(projectile, gameObject.transform.position + new Vector3(0, 7, 0), Quaternion.Euler(0, 0, 90));
            }
            else if (ShooterDirection.state == 2)
            {
                Instantiate(projectile, gameObject.transform.position + new Vector3(0, -7, 0), Quaternion.Euler(0, 0, 270));
            }

            fireTime += 1;
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

    public void EnemyDamage(int damage)
    {
        if (!healthBar.activeSelf)
        {
            healthBar.SetActive(true);
        }

        health -= damage;
    }
}
