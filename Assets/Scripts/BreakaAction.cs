using UnityEngine;
using System.Collections;
using CnControls;

public class BreakaAction : MonoBehaviour {
	public GameObject trail;
	public GameObject spark;
	public Transform spawnLoc;

	public float actionDrain;

	bool gottaGoFast = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(gottaGoFast)
			Controls.MovementSpeed = 24;
		else
			Controls.MovementSpeed = 15;

		if(CnInputManager.GetButtonDown("Submit"))
		{
			Instantiate(spark, spawnLoc.position, spawnLoc.rotation);

			trail.SetActive(true);
			gottaGoFast = true;

			if(CharacterSwap.energyBar.transform.localScale.x > actionDrain * 0.05f)
			{
				float x = CharacterSwap.energyBar.transform.localScale.x - (actionDrain * 0.05f);
				CharacterSwap.energyBar.transform.localScale = new Vector2 (x, CharacterSwap.energyBar.transform.localScale.y);
			}
		}

		if(CnInputManager.GetButtonUp("Submit"))
		{
			trail.SetActive(false);
			gottaGoFast = false;
		}

	}
}
