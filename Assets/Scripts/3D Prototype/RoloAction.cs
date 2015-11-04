using UnityEngine;
using System.Collections;
using CnControls;

public class RoloAction : MonoBehaviour {
	public GameObject arrow;
	public Transform spawnLoc;

	public float actionDrain;

	int bulletCount = 5;
	bool okToReload = true;
	
	// Use this for initialization
	
	// Update is called once per frames
	void Update () {
		Controls.MovementSpeed = 12f;

		if(CnInputManager.GetButtonDown("Submit") && bulletCount > 0)
		{
			Instantiate(arrow, spawnLoc.position, spawnLoc.rotation);
			bulletCount--;

			if(CharacterSwap.energyBar.transform.localScale.x > actionDrain * 0.05f)
			{
				float x = CharacterSwap.energyBar.transform.localScale.x - (actionDrain * 0.05f);
				CharacterSwap.energyBar.transform.localScale = new Vector2 (x, CharacterSwap.energyBar.transform.localScale.y);
			}

		}

		if(bulletCount <= 0 && okToReload)
		{
			StartCoroutine(Reload ());
			okToReload = false;
		}
		
	}

	IEnumerator Reload ()
	{
		yield return new WaitForSeconds(1);
		bulletCount = 5;
		okToReload = true;
	}
}
