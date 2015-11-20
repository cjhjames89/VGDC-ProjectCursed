using UnityEngine;
using System.Collections;

public class TestEnemy : MonoBehaviour {

    public static GameObject playerObject;
    public float speed;
    public Vector2 direction;

    // Use this for initialization
    void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        //Code that works in 3D
        var targetLocation = playerObject.transform;
        var move = new Vector2(targetLocation.position.x - transform.position.x, targetLocation.position.y - transform.position.y);
        direction = move;
        move.Normalize();
        transform.Translate(move * Time.deltaTime * speed);

        print(direction.magnitude);
        if (direction.magnitude < 5)
        {
            GameObject.Destroy(gameObject);
            HealthBar.takeDamage(1);
        }

        if(direction.magnitude < 7)
        {
            EnemyHealth.takeDamage(1);
        }



    }
}
