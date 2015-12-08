using UnityEngine;
using System.Collections;

public class PublicFunctions : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PhaseThruFriend(gameObject);
    }

    public static void PhaseThruFriend(GameObject thing)
    {
        GameObject[] friendlies = GameObject.FindGameObjectsWithTag("Friendly");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject col in friendlies)
        {
            Physics2D.IgnoreCollision(thing.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
        }

        foreach (GameObject col in players)
        {
            Physics2D.IgnoreCollision(thing.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
        }
    }
}
