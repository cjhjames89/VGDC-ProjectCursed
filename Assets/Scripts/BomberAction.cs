using UnityEngine;
using System.Collections;

public class BomberAction : MonoBehaviour {
    public GameObject Bomb;

	// Use this for initialization
	void Start ()
    {
        Bomb = GameObject.Find("Bomb");
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetButtonDown("Action"))
        {
            GameObject.Instantiate(Bomb);
        }
	}
}
