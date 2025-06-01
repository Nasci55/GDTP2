using UnityEngine;

public class Vault : MonoBehaviour
{
    [SerializeField]
    private CoinScript getPlayerStash;
    [SerializeField]
    //private int totalCoins = 0;
    public int totalCoins { get; private set; } = 0;

    private Collider2D playerCollider;
    public bool areTheCoinsInTheVault {  get; private set; }

    void Start()
    {
        playerCollider = getPlayerStash.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
       //Debug.Log($"{collider.name} is inside");
       if (collider == getPlayerStash.GetComponent<Collider2D>())
       {
            Debug.Log("Player is inside");
            totalCoins += getPlayerStash.coinStach;
            areTheCoinsInTheVault = true;
       }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider == getPlayerStash.GetComponent<Collider2D>())
        {
            areTheCoinsInTheVault = false;
        }
    }
}
