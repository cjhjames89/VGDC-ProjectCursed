using UnityEngine;
using System.Collections;

public class WizardAction : MonoBehaviour {
    public GameObject shield;
    private CircleCollider2D outer;
    private SpriteRenderer image;
    public float cost;

	// Use this for initialization
	void Start ()
    {
        shield.SetActive(true);

        outer = shield.GetComponent<CircleCollider2D>();
        outer.enabled = false;

        image = shield.GetComponent<SpriteRenderer>();
        image.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.localPosition = Vector3.zero;

        if (Input.GetButton("Action"))
        {
            outer.enabled = true;
            image.enabled = true;

            EnergyBar.accel = cost;
        }
        else
        {
            outer.enabled = false;
            image.enabled = false;

            EnergyBar.accel = 0;
        }
        
	}
}
