using UnityEngine;
using System.Collections;


public class PlayerBehavior : MonoBehaviour {

    public float speed = 2;
    public float jumpForce = 1;
    public float rotateSpeed = 1000;

    public Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        move();
        jump();
	}

    void move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    void jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce((Vector2.up + Vector2.right) * jumpForce);
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
    }
}
