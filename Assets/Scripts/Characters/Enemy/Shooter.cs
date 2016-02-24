using UnityEngine;
using System.Collections;

public class Shooter : CommonEnemy {
    public float range;
    public GameObject projectile;
    public float rate;
    private float fireTime;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        fireTime = 0;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        Vector3 Angle = (player.position - gameObject.transform.position).normalized;

        if (fireTime > 0)
        {
            fireTime -= Time.deltaTime;
        }

        if (difference <= range & fireTime <= 0)
        {
            Instantiate(projectile, gameObject.transform.position, Quaternion.Euler(0, 0, PublicFunctions.FindAngle(Angle.x, Angle.y)));

            fireTime += 1;
        }

        if (difference > 50)
        {
            transform.Translate(new Vector3(0,0,0));
        }
        else
        {
            if (difference > range * 0.7)
            {
                transform.Translate(direction * Time.deltaTime * speed);
            }
            else if (difference < range * 0.7)
            {
                transform.Translate(-direction * Time.deltaTime * speed);
            }
        }
    }
}
