using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour {

    public static float health;
    public static float speed;
    public static Transform player;
    private Vector3 direction1;
    private Vector3 direction2;
    private Vector3 move;
    private Vector3 endBounce;
    private Vector3 velocity;
    public BoxCollider2D enemyCollider;
    public BoxCollider2D playerCollider;

    // Use this for initialization
    void Start ()
    {
        health = 10f;
        speed = 4f;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        enemyCollider = gameObject.GetComponent<BoxCollider2D>();

        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();

        velocity = Vector3.zero;
    }

    void OnColliderEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HealthBar.takeDamage(1);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        direction1 = new Vector3(player.position.x - gameObject.transform.position.x, player.position.y - gameObject.transform.position.y, 0);

        move = direction1;

        direction2 = new Vector3(-direction1.x, direction1.y, direction1.z);

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

        if (health <= 0)
        {
            Destroy(gameObject);
        }

	}

}
