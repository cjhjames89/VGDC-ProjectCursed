using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour {

    public float decreaseSpeed = 0.08f;
    public static float accel;
    public static float fill;
    public static float instant;

    void Update ()
    {
        fill = GetComponent<Image>().fillAmount;

        //Change the fill amount of the sprite every frame. SMOOTH!
        fill -= (decreaseSpeed + accel) * Time.deltaTime + instant;
        GetComponent<Image>().fillAmount = fill;

        //If the energy bar is empty.
        if (GetComponent<Image>().fillAmount <= 0)
        {
            //Broadcast the message of empty energy. Message will be listened by the character controller.
            Messenger.Broadcast(GameEvent.EMPTY_ENERGY);

            //Refill the energy bar.
            //CAUTION: might need to change to broadcasting mechanism to listen to "character swapped" message before refilling.
            GetComponent<Image>().fillAmount = 1;
        }
	}

}
