using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private Collider2D coinColider;
    [SerializeField]
    private int coinValue = 1;
    [SerializeField]
    private int coinStach;
    [SerializeField]
    private GameObject coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == coinColider)
        {
            coinStach += coinValue;
            Destroy(coin);
        }
    }
}
