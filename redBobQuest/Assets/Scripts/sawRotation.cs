using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawRotation : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * -90);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Died");
    }
}
