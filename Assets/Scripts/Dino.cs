using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Rigidbody2D rb;

    private bool _isGameStarted = false;
    private bool _isTouchingGround = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool isJumpPressed = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow);
        bool isCrouchPressed = Input.GetKey(KeyCode.DownArrow) || Input.GetMouseButton(1) || Input.GetKey(KeyCode.LeftControl);
        if (isJumpPressed)
        {
            if (_isGameStarted && _isTouchingGround)
            {
                //jump
                Jump();
            }
            else
            {
                _isGameStarted = true;
                //start moving ground
                GameManager.Instance.gameStarted = true;
            }
        }
        else if (isCrouchPressed && _isTouchingGround)
        {
            //crouch

        }

        animator.SetBool("startedGame", _isGameStarted);
        animator.SetBool("crouching", isCrouchPressed && _isTouchingGround && !isJumpPressed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            _isTouchingGround = true;

        // if collision with obstacle---> game over
    }

    void Jump() { 
        rb.AddForce(Vector2.up * jumpForce); 
        _isTouchingGround = false;
    }

}
