using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI timerText;
    [SerializeField, Range(0f, 15.0f)]
    private float countdownTime;
    [SerializeField]
    private Vault vault;
    [SerializeField]
    private TextMeshProUGUI winText;
    private Vault vaultCoinTotal;

    void Start()
    {
        countdownTime *= 60;
        vaultCoinTotal = vault.GetComponent<Vault>();
        winText.gameObject.SetActive(false);
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
            SceneManager.LoadScene(3);
        }

        else
        {
            countdownTime -= Time.deltaTime;
        }
    }
}
