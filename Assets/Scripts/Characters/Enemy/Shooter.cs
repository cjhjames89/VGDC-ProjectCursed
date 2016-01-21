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
    private Vector3 direction;
    private float aroundTime;
    public GameObject HealthPickUp;
    public int dropPercent;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        healthBar.SetActive(false);

        health = totalHealth;

        fireTime = 0;

        aroundTime = 0;
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

        if (health <= 0)
        {
            System.Random drop = new System.Random();
            int chance = drop.Next(100);

            if (dropPercent > chance)
            {   
                Instantiate(HealthPickUp, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            }
            Destroy(gameObject);
        }

        if (aroundTime > 0)
        {
            direction = new Vector3(gameObject.transform.position.y - player.position.y, player.position.x - gameObject.transform.position.x, 0);
            aroundTime -= Time.deltaTime;
        }
        else
        {
            direction = new Vector3(player.position.x - gameObject.transform.position.x, player.position.y - gameObject.transform.position.y, 0);
        }
        
        direction.Normalize();

        

        transform.rotation = Quaternion.Euler(0, 0, 0);

        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Enemy", "Danger" });

        if (difference <= range & fireTime <= 0)
        {
            Instantiate(projectile, gameObject.transform.position, Quaternion.Euler(0, 0, PublicFunctions.FindAngle(Angle.x, Angle.y)));

            fireTime += 1;
        }

        if (difference > 50)
        {
            transform.Translate(new Vector3(0,0,0));
        }
        else
        {
            if (difference > range * 0.7)
            {
                transform.Translate(direction * Time.deltaTime * speed);
            }
            else if (difference < range * 0.7)
            {
                transform.Translate(-direction * Time.deltaTime * speed);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D wall)
    {
        if (wall.gameObject.CompareTag("Scenery"))
        {
            aroundTime++;
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
