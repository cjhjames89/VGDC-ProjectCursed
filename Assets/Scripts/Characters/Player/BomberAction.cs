using UnityEngine;
using System.Collections;

public class BomberAction : MonoBehaviour {
    public GameObject Bomb;
    public int limit;
    private int numBombs;
    public float cost;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.localPosition = Vector3.zero;
        //Sets this child game object to the same as the parent CharactherHolder

        numBombs = GameObject.FindGameObjectsWithTag("Friendly").Length;
        //Tracks the number of bombs in play

        if (Input.GetButtonDown("Action") & numBombs < limit)
        {
            Instantiate(Bomb, gameObject.transform.position + new Vector3(0, 0, 0), gameObject.transform.rotation);
            StartCoroutine(PublicFunctions.InstantDrain(cost));
        }//If button is pressed and the limit of bombs isn't reached, place a bomb
	}
}
