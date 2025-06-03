using UnityEngine;

public class EnemyTraper : MonoBehaviour
{
    [SerializeField]
    private int maxTraps = 5;
    [SerializeField]
    private int currentTraps;
    [SerializeField]
    private GameObject trapPrefab;
    [SerializeField]
    private float cooldownCounter = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Start()
    {
     
    }
    void Update()
    {
        if (cooldownCounter > 0)
        {
            cooldownCounter -= Time.deltaTime;
            Debug.Log("Cooldown: " + cooldownCounter);
        }
        if (cooldownCounter <= 0)
        {
            Instantiate(trapPrefab, transform.position, Quaternion.identity);
            cooldownCounter = 20f;
            Debug.Log("Trap placed. Cooldown reset.");
        }
    }
}
