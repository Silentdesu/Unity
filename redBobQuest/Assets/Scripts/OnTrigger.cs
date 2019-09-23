using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTrigger : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            player.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            player.SetActive(false);
    }
}
