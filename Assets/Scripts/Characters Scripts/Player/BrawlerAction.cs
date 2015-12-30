using UnityEngine;
using System.Collections;

public class BrawlerAction : MonoBehaviour {
    public GameObject PunchCollider;
    public float cost;
    public Animator animator;

    // Use this for initialization
    void Start()
    {
        PunchCollider.SetActive(false);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = Vector3.zero;

        if (Input.GetButton("Action"))
        {
            PunchCollider.SetActive(true);
            EnergyBar.accel = cost;
        }
        else
        {
            PunchCollider.SetActive(false);
            EnergyBar.accel = 0;
        }

        //////////ANIMATION//////////

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))    //activates right animation
        {
            animator.SetBool("BrawlerWalkRight", true);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))    //deactivates right animation
        {
            animator.SetBool("BrawlerWalkRight", false);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))    //activates right animation
        {
            animator.SetBool("BrawlerWalkLeft", true);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))    //deactivates right animation
        {
            animator.SetBool("BrawlerWalkLeft", false);
        }

        ///////END OF ANIMATION///////
    }

}
