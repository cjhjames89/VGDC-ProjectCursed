using UnityEngine;
using System.Collections;

public class WizardAction : MonoBehaviour {
    public GameObject shield;
    public float cost;

	// Use this for initialization
	void Start ()
    {
        shield.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.localPosition = Vector3.zero;

        if (Input.GetButton("Action"))
        {
            shield.SetActive(true);
            EnergyBar.accel = cost;
        }
        else
        {
            shield.SetActive(false);
            EnergyBar.accel = 0;
        }
        
	}
}
