using Unity.VisualScripting;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 100f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] 
    private Rigidbody2D playerRB;

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) >0)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            playerRB.gravityScale = 0f;
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, vertical * speed);
        }
        else
        {
            playerRB.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Tag_Ladder>())
        {
            isLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Tag_Ladder>())
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
