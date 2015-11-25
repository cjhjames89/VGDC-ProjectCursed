using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
    public static float speed;
    private float movement;
    public static float range;
    private Vector3 distance;
    public static float fireRate;
    private Vector3 player;
    private Vector2 move;
    public static float health;
    public Collider2D enemyCollider;
    public Collider2D playerCollider;

    // Use this for initialization
    void Start ()
    {
        health = 10f;
        range = 10f;
        speed = 4f;
        fireRate = 1f;
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        distance = new Vector3(gameObject.transform.position.x - player.x, gameObject.transform.position.x - player.x);
        move = new Vector2(gameObject.transform.position.x - player.x, gameObject.transform.position.y - player.y);

        move.Normalize();

        enemyCollider = gameObject.GetComponent<Collider2D>();

        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(player);

        /*
        if (distance.magnitude > range)
        {
            movement = speed;
        }
        else
        {
            StartCoroutine(shoot);
        }
        */

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(move * speed * Time.deltaTime);

        
    }

    /*Might want to make another object that attaches to shooter to find angle of player
    so that the whole sprite won't change angle*/

    IEnumerator shoot()
    {
        speed = 0f;

        GameObject.Instantiate(GameObject.FindGameObjectWithTag("Projectile"));

        yield return new WaitForSeconds(1 / fireRate);
    }
}
