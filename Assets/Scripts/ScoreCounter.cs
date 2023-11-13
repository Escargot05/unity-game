using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private AudioSource scoreSFX;

    TextMeshProUGUI scoreText;
    
    public int score { get; private set; }

    private void Awake()
    {
        score = 0;
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = $"Score: {score}";
    }

    public void AddScore(int scorePoints, bool playSound = false)
    {
        if (playSound)
        {
            scoreSFX.Play();
        }
        score += scorePoints;
        scoreText.text = $"Score: {score}";
    }
}
