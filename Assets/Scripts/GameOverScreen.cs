using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Text highestScore;
    void Start()
    {
        highestScore.text = "Your highest score: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
