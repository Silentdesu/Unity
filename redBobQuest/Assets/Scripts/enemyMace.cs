using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMace : MonoBehaviour
{
    public GameObject enemy;

    Vector2 startPoint;

    void Start()
    {
        startPoint = enemy.transform.position;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Debug.Log("Hit");
    }
}
