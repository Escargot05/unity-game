using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private AudioSource scoreSFX;

    // REMEMBER TO ADD TEXTMESHPRO TO YOUR PROJECT 
    // https://learn.unity.com/tutorial/working-with-textmesh-pro#
    private TextMeshProUGUI scoreText;
    private int score = 0;

    private void Start()
    {
        // component of type TextMeshProUGUI should exist on this object, so we use GetComponent<T>() method to get a reference
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

    public int GetScore()
    {
        return score;
    }
}
