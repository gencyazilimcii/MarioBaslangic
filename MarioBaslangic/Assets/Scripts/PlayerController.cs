using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;

    bool facingRiht = true;

    public float jumpSpeed = 1f,jumpFrequency=1f,nextJumpTime;

    public float moveSpeed = 6f;

    public bool isGrounded = false;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    private void Awake()
    {
        
    }
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

   
    void Update()
    {

        OnGroundCheck();

        HorizontalMove();

        if (playerRB.velocity.x<0 && facingRiht)
        {
            FlipFace();
        }

        else if (playerRB.velocity.x>0 && !facingRiht)
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical")>0 && isGrounded && (nextJumpTime< Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();

 
        }
    }

    private void FixedUpdate()
    {
        
    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }

    void FlipFace()
    {
        facingRiht = !facingRiht;
        Vector3 temploScale = transform.localScale;
        temploScale.x *= -1;
        transform.localScale = temploScale;
    }

    void Jump()
    {
        playerRB.AddForce(new Vector2(0f,jumpSpeed));
    }

    void OnGroundCheck()
    {
        isGrounded=Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRadius,groundCheckLayer);
        playerAnimator.SetBool("isGroundenAnim", isGrounded);
    }
}
