using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSwap : MonoBehaviour {

    [SerializeField] private GameObject[] characters;

    private uint charIndex;
	
    void Awake()
    {
        //Register to listen to the braodcast of empty energy.
        Messenger.AddListener(GameEvent.EMPTY_ENERGY, OnEmptyEnergy);
    }

    void OnDestroy()
    {
        //Remove the listener when this game object is destroyed.
        Messenger.RemoveListener(GameEvent.EMPTY_ENERGY, OnEmptyEnergy);
    }

    void Start()
    {
        charIndex = 0;
        PlayerCollisions.sprite = characters[0].GetComponent<SpriteRenderer>();
    }

    //Broadcast registered function.
    //When receive a broadcast of empty energy, swap the characters.
    private void OnEmptyEnergy()
    {
        //Set current to inactive.
        characters[charIndex % characters.Length].SetActive(false);

        //Set next to active.
        characters[++charIndex % characters.Length].SetActive(true);
        PlayerCollisions.sprite = characters[charIndex % characters.Length].GetComponent<SpriteRenderer>();
        EnergyBar.accel = 0;
    }
}
