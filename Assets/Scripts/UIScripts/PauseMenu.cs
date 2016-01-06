using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    private bool isPaused;

	//Initialization. Hide the menu when game begins.
	void Start () {
        isPaused = false;
        gameObject.SetActive(isPaused);
	}
	
    //Called by the UIController
	public void OnPauseResume () {
        isPaused = !isPaused;
        gameObject.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }
}
