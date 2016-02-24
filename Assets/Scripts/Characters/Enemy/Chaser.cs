using UnityEngine;
using System.Collections;
using System;

public class Chaser : CommonEnemy {

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (difference > 50)
        {
            transform.Translate(new Vector3(0, 0, 0));
        }
        else
        {
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }
}
