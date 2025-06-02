using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Vector2 velocity;
    [SerializeField]
    private CoinScript coinScript;

    [SerializeField]
    private GameObject pause;
    private int howManyCoins;

    [SerializeField, Header("Jump Stuff")]
    private float gravityScaling = 2.0f;
    [SerializeField]
    private float jumpMaxDuration = 0.1f;
    [SerializeField]
    private LayerMask groundCheckLayers;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundCheckRadius = 2.0f;

    private float jumpTimer;
    private bool isGrounded;
    private float originalGravity;
    private Vector2 currentVelocity;
    private Backpack doesThePlayerHaveTheBackpack;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
        pause.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        ComputeGrounded();
        Debug.Log(isGrounded);
        howManyCoins = coinScript.coinStach;

        float dir = Input.GetAxis("Horizontal");

        currentVelocity = rb.linearVelocity;

        currentVelocity.x = dir * velocity.x;

        if (dir < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (dir > 0)
        {
            transform.rotation = Quaternion.identity;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                currentVelocity.y = velocity.y;
                jumpTimer = 0.0f;
                rb.gravityScale = gravityScaling;
            }
        }
        else if (jumpTimer < jumpMaxDuration)
        {
            jumpTimer += Time.deltaTime;
            if (Input.GetKey(KeyCode.Space))
            {
                rb.gravityScale = Mathf.Lerp(gravityScaling, originalGravity, jumpTimer / jumpMaxDuration);
            }
            else
            {
                jumpTimer = jumpMaxDuration;
                rb.gravityScale = originalGravity;
            }
        }
        else
        {
            rb.gravityScale = originalGravity;
        }



        if (howManyCoins != 0)
        {
            currentVelocity.x = currentVelocity.x / howManyCoins;
            Debug.Log(howManyCoins);
        }

        rb.linearVelocity = currentVelocity;


        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0f;
            pause.SetActive(true);
        }
    }

    private void ComputeGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckLayers);

        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }


}
