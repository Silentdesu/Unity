using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashDetection : MonoBehaviour
{
    [SerializeField]
    AudioSource audio;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            audio.Play();
            Destroy(other.gameObject);
        }
    }
}
