using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;

    public LayerMask blockingLayer;

    private BoxCollider2D boxCollider;

	// Use this for initialization
	void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
        Debug.Log("x=" + boxCollider.size.x + " y=" + boxCollider.size.y);
	}
	
	// Update is called once per frame
	void Update () {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        if (hInput == 0 && vInput == 0)
            return;

        Vector3 inputVector = new Vector2(hInput, vInput);

        transform.Translate(inputVector * movementSpeed * Time.deltaTime);
    }

}
