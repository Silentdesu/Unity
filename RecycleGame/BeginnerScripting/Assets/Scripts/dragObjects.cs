using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragObjects : MonoBehaviour
{
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }
    void OnMouseDrag()
    {
        float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
        distanceToScreen));
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("DeadZone"))
        {
            transform.position = startPos;
            StartCoroutine(WhiteBack());
            GameObject.FindObjectOfType<Text>().GetComponent<timerScript>().score -= 5;
        }
    }

    IEnumerator WhiteBack()
    {
        GameObject.FindObjectOfType<Text>().GetComponent<Text>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        GameObject.FindObjectOfType<Text>().GetComponent<Text>().color = Color.white;
    }
}
