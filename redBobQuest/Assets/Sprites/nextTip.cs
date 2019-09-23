using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextTip : MonoBehaviour
{
    public GameObject image;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;

    void Start()
    {
        image.SetActive(true);
    }
    public void imageOne()
    {
        image.SetActive(false);
        image1.SetActive(true);
    }

    public void imageTwo()
    {
        image1.SetActive(false);
        image2.SetActive(true);
    }

    public void imageThree()
    {
        image2.SetActive(false);
        image3.SetActive(true);
    }
    
    public void returnToTheGame()
    {
        SceneManager.LoadScene("tutorial");
    }
}
