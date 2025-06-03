using UnityEngine;

public class TrapScript : MonoBehaviour
{
    [SerializeField]
    private CoinScript coinScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Destroy(gameObject);
            coinScript.coinStach = 0;
        }
    }
}
