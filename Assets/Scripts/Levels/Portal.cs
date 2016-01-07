using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
    public enum DoorLocation { North, East, South, West }

    public DoorLocation doorLocation; 
    public GameObject player;
    public GameObject mainCamera;
    public GameObject destinationRoom;
    public GameObject destination;

    private Portal destPortal;
    private Vector3 playerDest;
    private Vector3 cameraDest;
    private Vector3 playerDestOffset;

	// Use this for initialization
	void Start () {
        destPortal = destination.GetComponent<Portal>();
	    switch (destPortal.doorLocation)
        {
            case DoorLocation.North:
                playerDestOffset = new Vector3(0, 5, 0);
                break;
            case DoorLocation.East:
                playerDestOffset = new Vector3(5, 0, 0);
                break;
            case DoorLocation.South:
                playerDestOffset = new Vector3(0, -5, 0);
                break;
            case DoorLocation.West:
                playerDestOffset = new Vector3(-5, 0, 0);
                break;
        }

        playerDest = destination.transform.position + playerDestOffset;

        cameraDest = new Vector3(destinationRoom.transform.position.x, destinationRoom.transform.position.y, -20);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.transform.tag == "Player")
        {
            mainCamera.transform.position = cameraDest;
            player.transform.position = playerDest;
        }
    }
}
