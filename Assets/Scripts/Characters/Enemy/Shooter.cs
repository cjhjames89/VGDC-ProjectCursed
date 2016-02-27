using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
    public float range;
    public GameObject projectile;
    public float rate;
    private float fireTime;

    // Use this for initialization
    void Start()
    {
        fireTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CommonEnemy norm = gameObject.GetComponent<CommonEnemy>();

        Vector3 Angle = (norm.player.position - gameObject.transform.position).normalized;

        if (fireTime > 0)
        {
            fireTime -= Time.deltaTime;
        }

        if (norm.difference <= range & fireTime <= 0)
        {
            Instantiate(projectile, gameObject.transform.position, Quaternion.Euler(0, 0, PublicFunctions.FindAngle(Angle.x, Angle.y)));

            fireTime += 1;
        }

        if (norm.difference > 50)
        {
            transform.Translate(new Vector3(0,0,0));
        }
        else
        {
            if (norm.difference > range * 0.7)
            {
                transform.Translate(norm.direction * Time.deltaTime * norm.speed);
            }
            else if (norm.difference < range * 0.7)
            {
                transform.Translate(-norm.direction * Time.deltaTime * norm.speed);
            }
        }
    }
}
