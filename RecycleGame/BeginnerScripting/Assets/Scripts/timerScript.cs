using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timerScript : MonoBehaviour
{
    Text scoreText;

    public float score = 30f;

    void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        score -= Time.fixedDeltaTime;
        scoreText.text = "Timer: " + score.ToString("0");

        if (score <= 10)
            scoreText.color = Color.red;

        if (score < 0)
            SceneManager.LoadScene(0);
    }
}
