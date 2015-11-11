using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour {

    public static float health;
    public static float speed;
    public static Transform player;
    private Vector3 direction;
    private Vector3 oppDirection;

	// Use this for initialization
	void Start ()
    {
        health = 10f;
        speed = 4f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        direction = new Vector3(player.position.x - gameObject.transform.position.x, player.position.y - gameObject.transform.position.y);

        oppDirection = -direction;

        direction.Normalize();

        transform.Translate(direction * Time.deltaTime * speed);

        if (direction.x < 0)
        {
            //Sprite faces one direction;
        }
        else if (direction.x > 0)
        {
            //Sprite faces other direction;
        }

        //If it hits player, bounce away.
	}

    IEnumerator BounceBack ()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position - direction*3, ref oppDirection, 1);

        yield return new WaitForSeconds(1);
    }
}
