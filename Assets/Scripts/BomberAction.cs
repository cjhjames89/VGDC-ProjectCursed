using UnityEngine;
using System.Collections;

public class BomberAction : MonoBehaviour {
    public GameObject Bomb;
    public int limit;
    private int numBombs;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        numBombs = GameObject.FindGameObjectsWithTag("Friendly").Length;

        if (Input.GetButtonDown("Action") & numBombs < limit)
        {
            Instantiate(Bomb, gameObject.transform.position + new Vector3(-5, 0, 0), gameObject.transform.rotation);
        }
	}
}
