using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitPlayer : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetTrigger("isHit");
    }
}
