using UnityEngine;
using System.Collections;
using System.Linq;

public class PublicFunctions : MonoBehaviour
{
    public static void PhaseThruTag(GameObject thing, string[] Tags)
    {
        foreach (string tag in Tags)
        {
            GameObject[] objects = { };

            if (tag == "Enemy")
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                GameObject[] shields = GameObject.FindGameObjectsWithTag("EnemyShield");
                objects = enemies.Concat(shields).ToArray();
            }//Includes objects tagged for enemies and enemyshields
            else
            {
                objects = GameObject.FindGameObjectsWithTag(tag);
            }
               
            foreach (GameObject col in objects)
            {
                Physics2D.IgnoreCollision(thing.GetComponent<Collider2D>(), col.GetComponent<Collider2D>());
            }//Ignore collisions for each object with the tag
        }//Applies for each tag in the array
    }

    public static IEnumerator InstantDrain(float drain)
    {
        EnergyBar.instant = drain;
        yield return new WaitForSeconds(1 / 60);
        EnergyBar.instant = 0;
    }//For single-instance actions

    public static float WrapSin(float a)
    {
        if (a < 0)
        {
            a += 2 * Mathf.PI;
        }

        return a;
    }//To account for the range of asin.

    public static float FindAngle(float x, float y)
    {
        float result = 0;
        
        float[] xlist = { Mathf.Rad2Deg * Mathf.Acos(x), -Mathf.Rad2Deg * Mathf.Acos(x) };
        float[] ylist = { Mathf.Rad2Deg * WrapSin(Mathf.Asin(y)), 180 - (Mathf.Rad2Deg * WrapSin(Mathf.Asin(y))) };
        //Since each arc formula only accounts for half of the possible angles, both halves of each are covered

        float[] differences = {Mathf.Abs(xlist[0] - ylist[0]), Mathf.Abs(xlist[0] - ylist[1]),
                               Mathf.Abs(xlist[1] - ylist[0]), Mathf.Abs(xlist[1] - ylist[1])};
        //Tests all possible configurations of angles

        foreach (float a in xlist)
        {
            foreach (float b in ylist)
            {
                if (Mathf.Abs(a - b) == differences.Min())
                {
                    result = a;
                }
            }
        }//Picks the angle that is most likely to be true

        return result;
    }//Finds the angle between two objects

    public static void DamageEnemy(Collision2D hit, int damage)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            CommonEnemy c = hit.gameObject.GetComponent<CommonEnemy>();
            c.EnemyDamage(damage);
        }
        if (hit.gameObject.CompareTag("EnemyShield"))
        {
            EnemyShield s = hit.gameObject.GetComponent<EnemyShield>();
            s.EnemyDamage(damage);
        }
    }//Damages an enemy or enemyshield
}
