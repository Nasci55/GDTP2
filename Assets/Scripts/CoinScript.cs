using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private Collider2D coinColider;
    [SerializeField]
    private int coinValue = 1;
    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private Vault Vault;
    
    [SerializeField]
    public int coinStach { get; private set; } = 0;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider == coinColider)
        {
            coinStach += coinValue;
            Debug.Log($"You have {coinStach} coin/s");
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (Vault.areTheCoinsInTheVault == true)
        {
            coinStach = 0;
        }
    }
}
