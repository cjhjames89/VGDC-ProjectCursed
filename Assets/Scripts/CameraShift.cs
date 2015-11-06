using UnityEngine;
using System.Collections;

public class CameraShift : MonoBehaviour {

    public Transform playerPosition;
    public GameObject player;
    public Transform cameraPosition;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	
	// Update is called once per frame
	void Update () {
        playerPosition = player.transform;
        cameraPosition = gameObject.transform;
        
        if (playerPosition.position.x > cameraPosition.position.x + 20)
        {
            cameraPosition.Translate(20, 0, 0);
        }

        if (playerPosition.position.x < cameraPosition.position.x - 20)
        {
            cameraPosition.Translate(-20, 0, 0);
        }

        if (playerPosition.position.y > cameraPosition.position.y + 20)
        {
            cameraPosition.Translate(0, 20, 0);
        }

        if (playerPosition.position.y < cameraPosition.position.y - 20)
        {
            cameraPosition.Translate(0, -20, 0);
        }
    }
}
