using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour {

    public static float health;
    public static float speed;
    public static Transform player;
    private Vector3 direction1;
    private Vector3 direction2;
    private Vector3 move;
    private Vector3 oppDirection;
    public Collider2D enemyCollider;
    public Collider2D playerCollider;

    // Use this for initialization
    void Start ()
    {
        health = 10f;
        speed = 4f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        oppDirection = -direction1;

        enemyCollider = gameObject.GetComponent<Collider2D>();

        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }

    void OnTriggerEnter(Collider2D playerCollider)
    {
        StartCoroutine(BounceBack);
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

        //If it hits player, bounce away.
	}

    IEnumerator BounceBack ()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position - direction1*3, ref oppDirection, 1);

        yield return new WaitForSeconds(1);
    }
}
