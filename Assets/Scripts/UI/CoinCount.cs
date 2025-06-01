using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OkapiKit;
using System.Runtime.CompilerServices;

public class CoinCount : MonoBehaviour
{
    [SerializeField]
    private CoinScript getCoinStash;
    [SerializeField]
    public TextMeshProUGUI coinText;
    //private int coinCount = 0;
    private CoinScript coinTotal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinTotal = getCoinStash.GetComponent<CoinScript>();
    }

    void Update()
    {
        TextUpdate();
    }
    void TextUpdate()
    {
        if (coinTotal != null)
        {
            coinText.text = $"Coins: {coinTotal.coinStach}";
        }
        else
        {
            Debug.LogWarning("CoinScript component not found on the GameObject.");
            coinText.text = "Coins: 0";
        }
    }
}
