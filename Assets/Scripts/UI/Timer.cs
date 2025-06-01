using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI timerText;
    [SerializeField, Range(0f, 500.0f)]
    private float countdownTime;
    [SerializeField]
    private Vault vault;
    private Vault vaultCoinTotal;

    void Start()
    {
        vaultCoinTotal = vault.GetComponent<Vault>(); 
    }
    void Update()
    {
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";

        if (countdownTime <= 0)
        {
            countdownTime = 0;
            timerText.text = $"{minutes:00}:{seconds:00}";
            SceneManager.LoadScene(2);
        }

        else if (vaultCoinTotal.totalCoins >= 50)
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene(0);
        }

        else
        {
            countdownTime -= Time.deltaTime;
        }
    }
}
