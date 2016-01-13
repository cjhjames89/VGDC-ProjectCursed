using UnityEngine;
using System.Collections;
using System.Linq;

public class PublicFunctions : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PhaseThruTag(GameObject thing, string[] Tags)
    {
        GameObject[] enemyShooters = GameObject.FindGameObjectsWithTag("EnemyShooter");
        GameObject[] enemyChasers = GameObject.FindGameObjectsWithTag("EnemyChaser");

        GameObject[] enemies = enemyShooters.Concat(enemyChasers).ToArray();

        foreach (string tag in Tags)
        {
            GameObject[] objects = { };

            if (tag == "Enemy")
            {
                objects = enemies;
            }
            else
            {
                objects = GameObject.FindGameObjectsWithTag(tag);
            }
            
            foreach (GameObject col in objects)
            {
                Physics2D.IgnoreCollision(thing.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
            }
        }
    }
    /*
    public static void PhaseThruPlayer(GameObject thing)
    {
        GameObject[] friendlies = GameObject.FindGameObjectsWithTag("Friendly");
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject col in friendlies)
        {
            Physics2D.IgnoreCollision(thing.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
        }

        foreach (GameObject col in player)
        {
            Physics2D.IgnoreCollision(thing.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
        }
    }

    public static void PhaseThruFriend(GameObject thing)
    {
        GameObject[] friendlies = GameObject.FindGameObjectsWithTag("Friendly");

        foreach (GameObject col in friendlies)
        {
            Physics2D.IgnoreCollision(thing.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
        }
    }

    public static void PhaseThruEnemy(GameObject thing)
    {

        GameObject[] enemyShooters = GameObject.FindGameObjectsWithTag("EnemyShooter");
        GameObject[] enemyChasers = GameObject.FindGameObjectsWithTag("EnemyChaser");
        GameObject[] dangers = GameObject.FindGameObjectsWithTag("Danger");

        foreach (GameObject col in enemyShooters)
        {
            Physics2D.IgnoreCollision(thing.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
        }

        foreach (GameObject col in enemyChasers)
        {
            Physics2D.IgnoreCollision(thing.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
        }

        foreach (GameObject col in dangers)
        {
            Physics2D.IgnoreCollision(thing.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
        }
    }*/

    public static IEnumerator InstantDrain(float drain)
    {
        EnergyBar.instant = drain;
        yield return new WaitForSeconds(1 / 60);
        EnergyBar.instant = 0;
    }

    public static float WrapSin(float a)
    {
        if (a < 0)
        {
            a += 2 * Mathf.PI;
        }

        return a;
    }

    public static float FindAngle(float x, float y)
    {
        float result = 0;
        
        float[] xlist = { Mathf.Rad2Deg * Mathf.Acos(x), -Mathf.Rad2Deg * Mathf.Acos(x) };
        float[] ylist = { Mathf.Rad2Deg * WrapSin(Mathf.Asin(y)), 180 - (Mathf.Rad2Deg * WrapSin(Mathf.Asin(y))) };

        float[] differences = {Mathf.Abs(xlist[0] - ylist[0]), Mathf.Abs(xlist[0] - ylist[1]),
                               Mathf.Abs(xlist[1] - ylist[0]), Mathf.Abs(xlist[1] - ylist[1])};

        foreach (float a in xlist)
        {
            foreach (float b in ylist)
            {
                if (Mathf.Abs(a - b) == differences.Min())
                {
                    result = a;
                }
            }
        }

        return result;
    }

    public static void DamageEnemy(Collision2D hit, int damage)
    {
        if (hit.gameObject.CompareTag("EnemyChaser"))
        {
            //Chaser.EnemyDamage(damage);
            Chaser c = (Chaser)hit.collider.gameObject.GetComponent(typeof(Chaser));
            c.EnemyDamage(damage);
        }
        else if (hit.gameObject.CompareTag("EnemyShooter"))
        {
            Shooter s = (Shooter)hit.collider.gameObject.GetComponent(typeof(Shooter));
            s.EnemyDamage(damage);
        }
    }

}
