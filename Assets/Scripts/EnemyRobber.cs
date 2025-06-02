using UnityEngine;

public class EnemyRobber : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool checkEndOfPlatform = true;
    [SerializeField] private Transform checkEndOfPlatformTransform;
    [SerializeField] private bool checkWall = true;
    [SerializeField] private Transform checkWallTransform;
    [SerializeField] private LayerMask checkEndOfPlatformLayerMask;
    [SerializeField] private float sensorRadius;
    private Rigidbody2D rb;
    private Animator animator;

    private float direction = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created Unity Message | 0 references
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame

    void Update()
    {
        if (checkEndOfPlatform)
        {
            Collider2D collider = Physics2D.OverlapCircle(checkEndOfPlatformTransform.position, sensorRadius,
                                                          checkEndOfPlatformLayerMask);
            if (collider == null)
            {
                direction = -direction;
            }
        }

        if (checkWall)
        {
            Collider2D collider = Physics2D.OverlapCircle(checkWallTransform.position, sensorRadius,
                                                          checkEndOfPlatformLayerMask);
            if (collider != null)
            {
                direction = -direction;
            }
        }
        Vector2 currentVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
            
        rb.linearVelocity = currentVelocity;
        
        //animator.SetFloat("AbsVelocityX", Mathf.Abs(rb.linearVelocity.x));

        if ((direction < 0) && (transform.right.x > 0))
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else if ((direction > 0) && (transform.right.x < 0))
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if ((checkEndOfPlatform) && (checkEndOfPlatformTransform != null))
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(checkEndOfPlatformTransform.position, sensorRadius);
        }
        if ((checkWall) && (checkWallTransform != null))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(checkWallTransform.position, sensorRadius);
        }
    }
    // C�digo feito por Diogo Andrade!! 
}
