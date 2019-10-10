using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShaking : MonoBehaviour
{
    public GameObject cameraMain;
    Animator camAnim;
    AudioSource audio;

    void Awake()
    {
        camAnim = cameraMain.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        audio.Play();
        camAnim.SetTrigger("Shaking");
    }
}
