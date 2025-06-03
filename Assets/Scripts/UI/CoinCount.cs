using UnityEngine;
using TMPro;

public class CoinCount : MonoBehaviour
{
    [SerializeField]
    private CoinScript getCoinStash;
    [SerializeField]
    private Vault getVault;
    [SerializeField]
    public TextMeshProUGUI coinText;
    [SerializeField]
    public TextMeshProUGUI vaultText;
    private CoinScript coinTotal;
    private Vault vaultCoinTotal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinTotal = getCoinStash.GetComponent<CoinScript>();
        vaultCoinTotal = getVault.GetComponent<Vault>();
    }

    void Update()
    {
        TextUpdate();
    }

    void TextUpdate()
    {
        if (coinTotal != null && vaultCoinTotal != null)
        {
            coinText.text = $"Coins: {coinTotal.coinStach} *  {(1 + (coinTotal.coinStach / 100))}";
            vaultText.text = $"Vault: {vaultCoinTotal.totalCoins}";
        }
        else if (coinTotal == null || vaultCoinTotal == null)
        {
            Debug.LogWarning("CoinScript or Vault component GameObject missing!");
        }
        else
        {
            Debug.LogError("CoinScript and Vault component GameObject missing!!");
        }
    }
}
