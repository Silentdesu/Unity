using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject player;
    [Space]
    public float speed;
    public float jumpForce;
    public Animator animator;
    public bool IsGrounded;

    float jumpTimeCounter;
    public float jumpTime;
    float move;

    void Update()
    {
        move = Input.GetAxis("Horizontal");

        if (move < 0)
            rb.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        else if (move > 0)
            rb.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            player.SetActive(true);
        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(move));

        if (IsGrounded && Input.GetKeyDown(KeyCode.Space))
            rb.velocity = Vector2.up * jumpForce;


        if (IsGrounded && Input.GetKey(KeyCode.Space))
        {
            jumpTimeCounter = jumpTime;
            if (jumpTimeCounter > 0)
            {
                animator.SetBool("IsJump", true);
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            
        }else
            {
                animator.SetBool("IsJump", false);
            } 
    }

}
