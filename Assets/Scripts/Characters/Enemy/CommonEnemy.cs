using UnityEngine;
using System.Collections;

public class CommonEnemy : MonoBehaviour {
    public float totalHealth;
    private float health;
    public float speed;
    public Transform player;
    public GameObject healthBar;
    public Vector3 direction;
    private float aroundTime;
    public GameObject HealthPickUp;
    public int dropPercent;
    public float difference;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;

        healthBar.SetActive(false);

        health = totalHealth;

        aroundTime = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.transform.localScale = new Vector3(2 * health / totalHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        //Sets the position of the health bar.

        if (health <= 0)
        {
            System.Random drop = new System.Random();
            int chance = drop.Next(100);

            if (dropPercent > chance)
            {
                Instantiate(HealthPickUp, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            }
            Destroy(gameObject);
        }//If health is gone, try to drop health, and be destroyed.

        if (aroundTime > 0)
        {
            direction = new Vector3(gameObject.transform.position.y - player.position.y, player.position.x - gameObject.transform.position.x, 0);
            aroundTime -= Time.deltaTime;
        }
        else
        {
            direction = new Vector3(player.position.x - gameObject.transform.position.x, player.position.y - gameObject.transform.position.y, 0);
        }//If a wall is hit, travel perpendicular to target for one second. Otherwise, travel to the player.

        direction.Normalize();

        transform.rotation = Quaternion.Euler(0, 0, 0);
        difference = (player.position - gameObject.transform.position).magnitude;
        //Distance from the player

        PublicFunctions.PhaseThruTag(gameObject, new string[] { "Enemy", "Danger" });
        //Phase through all things tagged as enemies or dangerous to the player.

    }

    protected void OnCollisionEnter2D(Collision2D wall)
    {
        if (wall.gameObject.CompareTag("Scenery"))
        {
            aroundTime++;
        }//If a wall is hit, add one second to travel perpendicular.
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
