using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float healPower = 3;
    [SerializeField] private float rotateSpeed = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "First Person Player")
        {
            PickUp();
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.Rotate(0, rotateSpeed, 0);
    }

    public void PickUp()
    {
        player.GetComponent<PlayerStats>().Heal(healPower);
        Destroy(gameObject);
    }
}
