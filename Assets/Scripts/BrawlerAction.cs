using UnityEngine;
using System.Collections;

public class BrawlerAction : MonoBehaviour {
    public GameObject PunchCollider;

    // Use this for initialization
    void Start()
    {
        BoxCollider2D area = PunchCollider.GetComponent<BoxCollider2D>();
        PunchCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Action"))
        {
            PunchCollider.SetActive(true);
        }
        else
        {
            PunchCollider.SetActive(false);
        }
    }
}
