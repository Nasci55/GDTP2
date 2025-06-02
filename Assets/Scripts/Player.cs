using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 initialVelocity;
    private Vector2 velocity;
    private CoinScript coinScript;
    private int howManyCoins;

    void Start()
    {
        howManyCoins = coinScript.coinStach;

    }

    // Update is called once per frame
    void Update()
    {
        velocity = rb.linearVelocity;
        float dir = Input.GetAxis("Horizontal");
        if (howManyCoins != 0)
        {
            velocity.x = velocity.x / howManyCoins;
        }
 
        Debug.Log(velocity.x);
        rb.linearVelocity = velocity;
    }   

}
