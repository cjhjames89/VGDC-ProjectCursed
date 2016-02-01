using UnityEngine;
using System.Collections;

public class EnemyPause : MonoBehaviour {
    public GameObject enemy;
    public Portal portal;
    bool stayenabled = false;


    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (portal.IsInvoking("print"))
        {
            print("testing");
            stayenabled = !stayenabled;
            print(stayenabled);
        }
        if (stayenabled)
        {
            enemy.transform.Translate(new Vector3(0, 0, 0));

        }
    }
}
