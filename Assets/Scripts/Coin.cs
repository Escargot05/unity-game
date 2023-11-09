using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ScoreCounter scoreCounter;

    [SerializeField] private float rotateSpeed = 0.5f;

    private void OnTriggerEnter(Collider other) {
        if(other.name == "First Person Player") {
            PickUp();
        }
    }

    private void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>(); // this method returns object of type T found in scene,
                                                         // this way, we dont have to assign _coinCounter variable in each coin
    }

    private void Update()
    {
        // here spinning coin was implemented but I will not share this :)
        transform.Rotate(0, rotateSpeed, 0);
    }

    public void PickUp()
    {
        scoreCounter.AddScore(20, true);
        Destroy(gameObject);
    }
}
