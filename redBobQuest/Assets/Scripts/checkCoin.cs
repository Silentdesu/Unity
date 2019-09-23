using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkCoin : MonoBehaviour
{
    public GameObject coin;
    public GameObject word;

    private void Update()
    {
        if (coin.GetComponent<SpriteRenderer>().enabled == false)
            word.SetActive(true);
    }
}
