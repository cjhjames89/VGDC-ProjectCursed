using UnityEngine;
using System.Collections;

public class Suicide : MonoBehaviour {

    public GameObject explosion;
    public int damage;

    // Use this for initialization
    void Start () {
	
	}

    void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Explode());
        }
    }

    // Update is called once per frame
    void Update () {
        CommonEnemy norm = gameObject.GetComponent<CommonEnemy>();

        if (norm.difference > 50)
        {
            transform.Translate(new Vector3(0, 0, 0));
        }
        else
        {
            transform.Translate(norm.direction * Time.deltaTime * norm.speed);
        }
    }

    IEnumerator Explode()
    {
        explosion.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }
}
