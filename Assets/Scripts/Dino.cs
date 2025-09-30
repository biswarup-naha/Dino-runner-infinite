using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float jumpForce;
    //[SerializeField]
    private Rigidbody2D rb;

    private bool _isGameStarted = false;
    private bool _isTouchingGround = true;
    private Vector3 initialPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(transform.name);
        rb = GetComponent<Rigidbody2D>();
        initialPos = transform.position;
        Debug.Log(initialPos);
    }

    // Update is called once per frame
    void Update()
    {
        bool isJumpPressed = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow) || Input.touchCount > 0;
        bool isJumpReleased = Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.UpArrow) || Input.touchCount == 0;
        bool isCrouchPressed = Input.GetKey(KeyCode.DownArrow) || Input.GetMouseButton(1) || Input.GetKey(KeyCode.LeftControl);
        if (isJumpPressed)
        {
            if (_isGameStarted && _isTouchingGround)
            {
                //jump
                Jump();
            }
            //else if (_isGameStarted && !_isTouchingGround && isJumpReleased)
            //{
            //    transform.position = initialPos + Vector3.down*jumpForce*Time.deltaTime;
            //    _isTouchingGround = true;
            //}
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
        if (collision.gameObject.name.Contains("Obstacle"))
        {
            _isTouchingGround = true;
            Debug.Log("Game Over");
            Application.Quit();

            // This is useful for testing in the editor
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif

        }


        // if collision with obstacle---> game over
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
        //transform.position += Vector3.up*jumpForce*Time.deltaTime;
        //_isTouchingGround = false;
    }

}
