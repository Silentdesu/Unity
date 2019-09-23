using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maceHit : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        player.SetActive(true);
    }
}
