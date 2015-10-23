using UnityEngine;
using System.Collections;
using CnControls;

public class IssacAction : MonoBehaviour {
	public Transform leftArm;
	public Transform rightArm;
	public Transform L;
	public Transform R;
	Vector3 laStartPos;
	Vector3 raStartPos;

	bool isPunching;
	bool leftPunch;
	bool rightPunch;

	public int punchSpeed = 1;
	public GameObject wave;

	public float actionDrain;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		Controls.MovementSpeed = 17;

		laStartPos = new Vector3 (L.position.x, L.position.y, L.position.z);
		raStartPos = new Vector3 (R.position.x, R.position.y, R.position.z);

		if(CnInputManager.GetButtonDown("Submit") && !isPunching)
		{
			StartCoroutine(TimeToPunch());

			if(CharacterSwap.energyBar.transform.localScale.x > actionDrain * 0.05f)
			{
				float x = CharacterSwap.energyBar.transform.localScale.x - (actionDrain * 0.05f);
				CharacterSwap.energyBar.transform.localScale = new Vector2 (x, CharacterSwap.energyBar.transform.localScale.y);
			}
		}

		if(isPunching)
		{
			if(leftPunch)
			{
				leftArm.Translate(Vector3.forward * punchSpeed * Time.deltaTime);
				rightArm.Translate(Vector3.back * punchSpeed * Time.deltaTime);
			}
			else
			{
				rightArm.Translate(Vector3.forward * punchSpeed * Time.deltaTime);
				leftArm.Translate(Vector3.back * punchSpeed * Time.deltaTime);
			}

		}

	}

	IEnumerator TimeToPunch ()
	{
		isPunching = true;
		leftPunch = true;
		yield return new WaitForSeconds(0.25f);
		Instantiate(wave, L.position, L.rotation);
		leftPunch = false;
		yield return new WaitForSeconds(0.5f);
		Instantiate(wave, R.position, R.rotation);
		leftPunch = true;
		yield return new WaitForSeconds(0.25f);
		isPunching = false;
		leftArm.position = laStartPos;
		rightArm.position = raStartPos;
	}
}
