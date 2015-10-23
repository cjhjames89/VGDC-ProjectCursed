using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSwap : MonoBehaviour {
	public GameObject[] characters;
	int characterIndex;

	public static float drain;
	public static Image energyBar;
	float initialWidth;
	

	void Awake ()
	{
		energyBar = GameObject.FindWithTag("Energy Bar").GetComponent<Image>();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(EnergyDrain());
		drain = 5f;
		initialWidth = energyBar.transform.localScale.x;
		characterIndex = 0;
	}

	void Update ()
	{
		if (energyBar.transform.localScale.x < 0)
			energyBar.transform.localScale = new Vector2 (0, energyBar.transform.localScale.y);
	}


	IEnumerator EnergyDrain ()
	{
		//Drains the energybar every second
		yield return new WaitForSeconds(1);

		//If the energybar is depleted then the for statement will go through the array
		//and make the next character available while deactivating the previous one. Then the 
		//energy bar is reset.
		if(energyBar.transform.localScale.x <= 0)
		{
			for(int i = 0; i < characters.Length; i++)
			{
				if(characterIndex.Equals(i) && characters[i].activeSelf == true)
				{
					characters[i].SetActive(false);
					if(characterIndex == characters.Length - 1)
					{
						characters[0].SetActive(true);
					}
					else
					{
						characters[i + 1].SetActive(true);
					}
				}
			}
			if(characterIndex < characters.Length - 1)
				characterIndex++;
			else
				characterIndex = 0;
			
			Debug.Log ("Character Index - " + characterIndex + " Array Length Check - " + (characters.Length - 1));

			energyBar.transform.localScale = new Vector2 (initialWidth, energyBar.transform.localScale.y);
		}
		else
		{
			float x = energyBar.transform.localScale.x - (drain * 0.05f);
			energyBar.transform.localScale = new Vector2(x, energyBar.transform.localScale.y);
		}



		StartCoroutine(EnergyDrain());
	}
}
