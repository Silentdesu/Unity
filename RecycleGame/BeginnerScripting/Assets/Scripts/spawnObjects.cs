using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObjects : MonoBehaviour
{
    public GameObject[] trashObjects;

    void Start()
    {
        int randomNum = Random.Range(0, trashObjects.Length);
        Instantiate(trashObjects[randomNum], transform.position, Quaternion.identity);
    }
}
