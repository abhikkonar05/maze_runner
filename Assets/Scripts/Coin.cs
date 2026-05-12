using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 10;
    public AudioClip collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.AddScore(coinValue);

            AudioSource.PlayClipAtPoint(
                collectSound,
                transform.position
            );

           Destroy(transform.root.gameObject);
        }
    }
}