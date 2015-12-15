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
        Vector3 Angle = (player.position - gameObject.transform.position).normalized;

        if (fireTime > 0)
        {
            fireTime -= Time.deltaTime;
        }

        healthBar.transform.localScale = new Vector3(2 * health / totalHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        Vector3 direction1 = new Vector3(player.position.x - gameObject.transform.position.x, player.position.y - gameObject.transform.position.y, 0);

        direction1.Normalize();

        if (difference <= range & fireTime <= 0)
        {
            Instantiate(projectile, gameObject.transform.position + Angle * 7, Quaternion.Euler(0, 0, PublicFunctions.FindAngle(Angle.x, Angle.y)));

            fireTime += 1;
        }

        if (difference > range*0.8)
        {
            transform.Translate(direction1 * Time.deltaTime * speed);
        }
        else if (difference < range*0.8)
        {
            transform.Translate(-direction1 * Time.deltaTime * speed);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        PublicFunctions.PhaseThruEnemy(gameObject);

        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
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
