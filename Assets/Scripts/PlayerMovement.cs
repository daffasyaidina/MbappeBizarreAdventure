using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player_rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    private bool doubleJump;
    private bool isWallJumping;
    private bool isWallSliding;
    private float wallJumpDir;
    private float wallJumpTime = .2f;
    private float wallJumpCounter;
    private float wallJumpDuration;
    private float wallSlidingSpeed = 2f;
    private float dirX;
    private Vector2 wallJumpPower = new Vector2(8f, 20f);

    [SerializeField] private int moveSpeed = 7;
    [SerializeField] private int jumpForce = 20;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask jumpableGround;
    

    private enum MovementState { Idle, Running, Jumping, Falling, DoubleJump}

    [SerializeField] private AudioSource JumpSFX;
    // Start is called before the first frame update
    private void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        player_rb.velocity = new Vector2(dirX * moveSpeed, player_rb.velocity.y);

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                JumpSFX.Play();
                player_rb.velocity = new Vector2(player_rb.velocity.x, jumpForce);

                doubleJump = !doubleJump;
            }
        }
        if (Input.GetButtonUp("Jump") && player_rb.velocity.y > 0f)
        {
            player_rb.velocity = new Vector2(player_rb.velocity.x, player_rb.velocity.y * 0.5f);
        }
        UpdateAnimationState();

        WallSlide();

        WallJump();
        
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0)
        {
            sprite.flipX = false;
            state = MovementState.Running;
        }
        else if (dirX < 0)
        {
            state = MovementState.Running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (player_rb.velocity.y > .1f)
        {
            state = MovementState.Jumping;
        }
        else if (player_rb.velocity.y < -.1f)
        {
            state = MovementState.Falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsWalled_R()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.right, .2f, wallLayer);
    }

    private bool IsWalled_L()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.left, .2f, wallLayer);
    }

    private void WallSlide()
    {
        if ((IsWalled_R() && !IsGrounded() && dirX != 0f) || (IsWalled_L() && !IsGrounded() && dirX != 0f))
        {
            isWallSliding = true;
            player_rb.velocity = new Vector2(player_rb.velocity.x, Mathf.Clamp(player_rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, .1f, jumpableGround);
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpCounter = wallJumpTime;

            CancelInvoke(nameof(StopWallJump));
        }
        else
        {
            wallJumpCounter -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && wallJumpCounter > 0f)
        {
            isWallJumping = true;
            player_rb.velocity = new Vector2(wallJumpDir * wallJumpPower.x, wallJumpPower.y);
            wallJumpCounter = 0f;

            Invoke(nameof(StopWallJump), wallJumpDuration);
        }
    }

    private void StopWallJump()
    {
        isWallJumping = false;
    }
}
