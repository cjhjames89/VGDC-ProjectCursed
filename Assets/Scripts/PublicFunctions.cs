using UnityEngine;
using System.Collections;
using System.Linq;

public class PublicFunctions : MonoBehaviour
{
    public static void PhaseThruTag(GameObject thing, string[] Tags)
    {
        GameObject[] enemyShooters = GameObject.FindGameObjectsWithTag("EnemyShooter");
        GameObject[] enemyChasers = GameObject.FindGameObjectsWithTag("EnemyChaser");
        GameObject[] enemyProtectors = GameObject.FindGameObjectsWithTag("EnemyProtector");
        GameObject[] enemyShields = GameObject.FindGameObjectsWithTag("EnemyShield");

        GameObject[] enemies = enemyShooters.Concat(enemyChasers).ToArray();
        enemies = enemies.Concat(enemyProtectors).ToArray();
        enemies = enemies.Concat(enemyShields).ToArray();

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
        else if (hit.gameObject.CompareTag("EnemyProtector"))
        {
            Protector p = (Protector)hit.collider.gameObject.GetComponent(typeof(Protector));
            p.EnemyDamage(damage);
        }
        else if (hit.gameObject.CompareTag("EnemyShield"))
        {
            EnemyShield s = (EnemyShield)hit.collider.gameObject.GetComponent(typeof(EnemyShield));
            s.EnemyDamage(damage);
        }
    }

}
