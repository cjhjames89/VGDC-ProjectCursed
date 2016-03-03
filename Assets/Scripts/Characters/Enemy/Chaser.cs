using UnityEngine;
using System.Collections;
using System;

public class Chaser : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        CommonEnemy norm = gameObject.GetComponent<CommonEnemy>();

        if (norm.difference > 50)
        {
            transform.Translate(new Vector3(0, 0, 0));
        }
        else
        {
            transform.Translate(norm.direction * Time.deltaTime * norm.speed);
        }//Move to player if it's close enough
    }
}
