using UnityEngine;
using System.Collections;

public class BombAction : MonoBehaviour {
    private bool isArmed;
    public static float armTime;
    public static float radius;
    public static float range;
    private bool isDetonated;

	// Use this for initialization
	void Start ()
    {
        armTime = 1f;
        radius = 3f;
        range = 0.5f;
        isArmed = false;
        isDetonated = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
	}

    void OnColliderEnter(Collider other)
    {
        if (isDetonated == false)
        {
            isDetonated = true;
        }
        else
        {
            //Destroy enemies within the new explosion radius
        }
        
    }

	// Update is called once per frame
	void Update ()
    {
        
	    if (isDetonated == true)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
	}
}
