using UnityEngine;
using System.Collections;

public class Protector : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        CommonEnemy norm = gameObject.GetComponent<CommonEnemy>();

        Vector3 against = norm.player.position;

        GameObject[] partners = GameObject.FindGameObjectsWithTag("Enemy");

        Vector3 partner = getShortest(partners, 50).transform.position;

        Vector3 destination = guardPosition(against, partner, 12);

        Vector3 direction = destination - gameObject.transform.position;

        gameObject.transform.Translate(direction * Time.deltaTime * norm.speed);
	}

    GameObject getShortest(GameObject[] possibles, float range)
    {
        float minDistance = range;
        GameObject result = gameObject;

        foreach (GameObject pos in possibles)
        {
            if ((gameObject.transform.position - pos.transform.position).magnitude < minDistance & pos != gameObject)
            {
                minDistance = (gameObject.transform.position - pos.transform.position).magnitude;
                result = pos;
            }
        }

        return result;
    }

    Vector3 guardPosition(Vector3 attacker, Vector3 priority, float forward)
    {
        Vector3 angle = attacker;

        Vector3 result = (angle - priority).normalized*forward + priority;

        return result;
    }
}
