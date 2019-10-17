using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;

    private float speed = 5;
    private float hor;
    Vector3 moveRight = new Vector3(1, 1, 0);
    Vector3 moveLeft = new Vector3(-1, 1, 0);


    void Start()
    {

    }

    void Update()
    {

        hor = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y <= Mathf.Epsilon)
        {
            rb.velocity = new Vector2(0, 10);
        }

        if (hor > 0)
        {
            transform.localScale = moveRight;
        }
        else if (hor < 0)
        {
            transform.localScale = moveLeft;
        }

        DoAnims();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PickMe")
        {
            Destroy(collision.gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * hor * speed * Time.fixedDeltaTime);
    }


    void DoAnims()
    {
        anim.SetFloat("Run", Mathf.Abs(hor));
        anim.SetFloat("Jump", Mathf.Abs(rb.velocity.y));
    }


}
