using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private Collider2D coinColider;
    [SerializeField]
    private float coinValue = 1;
    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private Vault Vault;
    
    [SerializeField]
    public float coinStach { get; private set; } = 0;

    [SerializeField]
    private float enemyCooldown = 5;

    private void Update()
    {
        enemyCooldown -= Time.deltaTime;    
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider == coinColider)
        {
            coinStach += coinValue;
            Debug.Log($"You have {coinStach} coin/s");
        }        
        if (collider.GetComponentInParent<EnemyRobber>())
        {

            if (enemyCooldown < 0)
            {
                if (coinStach > 20)
                {
                    coinStach -= 30;
                    enemyCooldown = 5;
                }
                else
                {
                    coinStach = 0;
                    enemyCooldown = 5;
                }
            }
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
