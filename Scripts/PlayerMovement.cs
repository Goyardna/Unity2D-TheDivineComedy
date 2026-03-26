using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    private BoxCollider2D coll; // 修改为 BoxCollider2D
    private SpriteRenderer sprite;
    private Animator anim;

    [Header("Layer")]
    [SerializeField] private LayerMask jumpableGround;

    [Header("Movement")]
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;
    private int jumpCount = 0;
    private const int maxJumpCount = 1;

    /*----------------------------------------*/
    private enum MovementState { idle, running, jumping, falling }
    [SerializeField] private AudioSource jumpSoundEffect;

    /*----------------------------------------*/
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>(); // 修改为 BoxCollider2D
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    /*----------------------------------------*/
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        bool isGrounded = IsGrounded();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpSoundEffect.Play();
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount = 1;
        }
        else if (Input.GetButtonDown("Jump") && !isGrounded && jumpCount < maxJumpCount)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount++;
        }

        UpdateAnimationState();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((1 << collision.gameObject.layer & jumpableGround) != 0)
        {
            jumpCount = 0;
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        // 水平移动状态
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        // 垂直移动状态（覆盖水平状态）
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(
            coll.bounds.center,
            coll.bounds.size,
            0f,
            Vector2.down,
            0.2f,
            jumpableGround);
    }
}