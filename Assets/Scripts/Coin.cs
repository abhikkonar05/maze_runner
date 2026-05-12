using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.AddScore(points);

            Destroy(gameObject);
        }
    }
}