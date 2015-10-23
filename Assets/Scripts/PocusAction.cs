using UnityEngine;
using System.Collections;
using CnControls;

public class PocusAction : MonoBehaviour {
	public GameObject forceField;
	public Transform spawnLoc;
	GameObject instance;

	public GameObject wandHand;
	int spinSpeed = 500;

	public float actionDrain;

	public int sizeAmount;
		

	// Update is called once per frame
	void Update () {
		Controls.MovementSpeed = 6f;

		if(CnInputManager.GetButtonDown("Submit"))
		{
			instance = (GameObject) Instantiate(forceField, spawnLoc.position, spawnLoc.rotation);
			Debug.Log (instance + "'s size is " + instance.transform.localScale);
			CancelInvoke("Expand");
		}

		if(CnInputManager.GetButton("Submit") && !IsInvoking ("Expand"))
		{
			wandHand.transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
			wandHand.transform.Translate(Vector3.left * spinSpeed/150 * Time.deltaTime);
			Invoke ("Expand", 0.05f);
		}

		if(CnInputManager.GetButtonUp("Submit"))
		{
			CancelInvoke("Expand");
		}
	}

	void Expand ()
	{
		instance.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

		if(instance.transform.localScale.x >= 10 || instance.transform.localScale.y >= 10 || instance.transform.localScale.z >= 10)
		{
			instance.transform.localScale = new Vector3(10, 10, 10);
		}

		if(CharacterSwap.energyBar.transform.localScale.x > actionDrain * 0.05f)
		{
			float x = CharacterSwap.energyBar.transform.localScale.x - (actionDrain * 0.05f);
			CharacterSwap.energyBar.transform.localScale = new Vector2 (x, CharacterSwap.energyBar.transform.localScale.y);
		}
	}
}
