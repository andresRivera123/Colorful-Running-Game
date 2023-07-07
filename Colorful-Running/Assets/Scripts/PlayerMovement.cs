using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool OnFloor = false;
    private Animator animator;
    [SerializeField] private float jumpForce = 6f;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Salto
        if (OnFloor)
        {
            if (Input.GetKey("space"))
            {
                animator.SetBool("Jump", true);
                rb.velocity = new Vector2(0, jumpForce);
                //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Floor")
        {
            animator.SetBool("Jump", false);
            OnFloor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Floor")
        {
            OnFloor = false;
        }
    }
}
