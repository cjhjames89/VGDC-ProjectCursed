using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {
    private bool active;
    private Transform[] objectList = { };

	// Use this for initialization
	void Start ()
    {
        active = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            active = true;
            // Instantiate all objects in objectList at their stored transforms and clear the list.
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag != "Plyer" & other.gameObject.tag != "Room" & !active)
        {
            // Add object to objectList to be instantiated when player enters room again.
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            active = false;
        }
    }
}
