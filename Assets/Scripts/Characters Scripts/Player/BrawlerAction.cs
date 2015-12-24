using UnityEngine;
using System.Collections;

public class BrawlerAction : MonoBehaviour {
    public GameObject PunchCollider;
    public float cost;

    // Use this for initialization
    void Start()
    {
        PunchCollider.SetActive(false);
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
    }
}
