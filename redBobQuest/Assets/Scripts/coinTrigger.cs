using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("You've got a coin");
    }
}
