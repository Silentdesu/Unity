using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinDisappear : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
