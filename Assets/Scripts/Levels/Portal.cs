using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
    public enum DoorLocation { North, East, South, West }

    public DoorLocation doorLocation; 
    public GameObject player;
    public GameObject mainCamera;
    public GameObject destination;

    private GameObject thisRoom;
    private Vector3 playerDest;
    private Vector3 cameraDest;

	// Use this for initialization
	void Start () {
        thisRoom = transform.parent.gameObject;
        switch (doorLocation)
        {
            case DoorLocation.East:
                playerDest = new Vector3(destination.transform.position.x - 12, destination.transform.position.y, 0);
                cameraDest = new Vector3(thisRoom.transform.position.x + 150, thisRoom.transform.position.y, -20);
                break;
            case DoorLocation.North:
                playerDest = new Vector3(destination.transform.position.x, destination.transform.position.y - 12, 0);
                cameraDest = new Vector3(thisRoom.transform.position.x, thisRoom.transform.position.y + 90, -20);
                break;
            case DoorLocation.South:
                playerDest = new Vector3(destination.transform.position.x, destination.transform.position.y + 12, 0);
                cameraDest = new Vector3(thisRoom.transform.position.x, thisRoom.transform.position.y - 90, -20);
                break;
            case DoorLocation.West:
                playerDest = new Vector3(destination.transform.position.x + 12, destination.transform.position.y, 0);
                cameraDest = new Vector3(thisRoom.transform.position.x - 150, thisRoom.transform.position.y, -20);
                break;
        }

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
