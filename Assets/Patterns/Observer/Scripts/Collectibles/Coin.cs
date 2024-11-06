using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 10;  // Сколько монет дает

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.CollectCoin(value);
            Destroy(gameObject);       
        }
    }
}