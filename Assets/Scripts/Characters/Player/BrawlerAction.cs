using UnityEngine;
using System.Collections;

public class BrawlerAction : MonoBehaviour {
    public GameObject PunchCollider;
    public float cost;
    public Animator animator;
    private float PunchTime;

    // Use this for initialization
    void Start()
    {
        PunchCollider.SetActive(false);
        animator = GetComponent<Animator>();
        PunchTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = Vector3.zero;
        //Sets this child game object to the same as the parent CharactherHolder

        if (PunchTime > 0)
        {
            PunchTime -= Time.deltaTime;
        }//Punch recharging

        if (Input.GetButtonDown("Action") & PunchTime <= 0)
        {
            StartCoroutine(Punch());
            StartCoroutine(PublicFunctions.InstantDrain(cost));
            PunchTime += 1;
        }//Punch if it's ready, and start recharging

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

    private IEnumerator Punch()
    {
        PunchCollider.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        PunchCollider.SetActive(false);
    }//Place fist and take it back
}
