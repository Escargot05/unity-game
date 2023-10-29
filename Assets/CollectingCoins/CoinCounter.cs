using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CoinCounter : MonoBehaviour
{
    // REMEMBER TO ADD TEXTMESHPRO TO YOUR PROJECT 
    // https://learn.unity.com/tutorial/working-with-textmesh-pro#
    private TextMeshProUGUI coinCounterText;
    private int coinCount = 0;
    
    private void Start()
    {
        // component of type TextMeshProUGUI should exist on this object, so we use GetComponent<T>() method to get a reference
        coinCounterText = GetComponent<TextMeshProUGUI>();
        coinCounterText.text = $"Coins: {coinCount}";
    }

    public void AddCoin()
    {
        coinCount++;
        coinCounterText.text = $"Coins: {coinCount}";
    }
}
