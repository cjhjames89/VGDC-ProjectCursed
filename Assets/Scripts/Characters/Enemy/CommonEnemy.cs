using UnityEngine;
using System.Collections;

public class CommonEnemy : MonoBehaviour {
    public float totalHealth;
    protected float health;
    public float speed;
    protected Transform player;
    public GameObject healthBar;
    protected Vector3 direction;
    protected float aroundTime;
    public GameObject HealthPickUp;
    public int dropPercent;
    protected float difference;

    // Use this for initialization
    protected virtual void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;

        healthBar.SetActive(false);

        health = totalHealth;

        aroundTime = 0;
    }
	
	// Update is called once per frame
	protected virtual void Update ()
    {
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
        difference = (player.position - gameObject.transform.position).magnitude;

        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Enemy", "Danger" });

    }

    protected void OnCollisionEnter2D(Collision2D wall)
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
