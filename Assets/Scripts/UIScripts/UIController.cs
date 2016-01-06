using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

    [SerializeField]
    private PauseMenu pauseMenu;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //Player pressed <Esc> to pause/resume the game.
        if (Input.GetKeyDown(KeyCode.Escape))
            pauseMenu.OnPauseResume();
    }
}
