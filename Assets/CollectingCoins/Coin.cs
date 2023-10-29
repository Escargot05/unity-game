using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinCounter _coinCounter;

    [SerializeField] private float rotateSpeed = 0.5f;

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        if(other.name == "First Person Player") {
            PickUp();
        }
    }

    private void Start()
    {
        _coinCounter = FindObjectOfType<CoinCounter>(); // this method returns object of type T found in scene,
                                                        // this way, we dont have to assign _coinCounter variable in each coin
    }

    private void Update()
    {
        // here spinning coin was implemented but I will not share this :)
        transform.Rotate(rotateSpeed, rotateSpeed, rotateSpeed);
    }

    public void PickUp()
    {
        _coinCounter.AddCoin();
        Destroy(gameObject);
    }
}
