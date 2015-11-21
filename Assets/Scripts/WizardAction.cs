using UnityEngine;
using System.Collections;

public class WizardAction : MonoBehaviour {
    public GameObject shield;
    public static float shieldSpeed;
    public static float shieldExpansion;
    public static int team = 1;

	// Use this for initialization
	void Start ()
    {
        shield = GameObject.Find("Shield");
        shieldSpeed = 2f;
        shieldExpansion = Mathf.Sqrt(shieldSpeed * Time.deltaTime / Mathf.PI);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Action"))
        {
            while (Input.GetButton("Aciton"))
            {
                /*
                shield.transform.lossyScale.x = shieldExpansion;
                shield.transform.localScale.y = shieldExpansion;
                shield.transform.localScale.z = shieldExpansion;
                */
            }
            Instantiate(shield);
        }
	}
}
