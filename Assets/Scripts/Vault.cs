using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vault : MonoBehaviour
{
    [SerializeField]
    private CoinScript getPlayerStash;
    [SerializeField]
    //private int totalCoins = 0;
    public float totalCoins { get; private set; } = 0;
    [SerializeField]
    private TextMeshProUGUI winText;
    private Collider2D playerCollider;
    public bool areTheCoinsInTheVault { get; private set; }

    void Start()
    {
        playerCollider = getPlayerStash.GetComponent<Collider2D>();
        winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WinScene());
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log($"{collider.name} is inside");
        if (collider.GetComponent<CoinScript>())
        {
            Debug.Log("Player is inside");
            totalCoins += getPlayerStash.coinStach * (1 + (getPlayerStash.coinStach/100));
            areTheCoinsInTheVault = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<CoinScript>())
        {
            areTheCoinsInTheVault = false;
        }
    }

    private IEnumerator WinScene()
    {
        if (totalCoins >= 20)
        {
            winText.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(0);
        }
    }
}
