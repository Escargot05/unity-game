using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
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
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        transform.Rotate(0, rotateSpeed, 0);
    }

    public void PickUp()
    {
        playerStats.Heal(healPower);
        Destroy(gameObject);
    }
}
