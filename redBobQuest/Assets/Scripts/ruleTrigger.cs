using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ruleTrigger : MonoBehaviour
{
    public void OnRuleClick()
    {
        SceneManager.LoadScene("Rules");
    }
}
