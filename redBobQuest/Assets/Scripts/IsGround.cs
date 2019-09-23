using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour
{
    public GameObject player;
    void OnCollisionEnter2D(Collision2D collision)
    {
        player.GetComponent<playerController>().IsGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        player.GetComponent<playerController>().IsGrounded = false;
    }
}
