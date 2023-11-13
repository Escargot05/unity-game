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
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    private void Update()
    {
        transform.Rotate(0, rotateSpeed, 0);
    }

    public void PickUp()
    {
        scoreCounter.AddScore(20, true);
        Destroy(gameObject);
    }
}
