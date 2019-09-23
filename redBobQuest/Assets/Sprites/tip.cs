using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tip : MonoBehaviour
{

    public void OnClickTip()
    {
        SceneManager.LoadScene("tips");
    }

}
