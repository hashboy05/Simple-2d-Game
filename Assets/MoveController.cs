using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private float xInput;

    [Header("Collision Check")]
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private Transform groundCheck;
    private bool isGrounded;
    [SerializeField] private LayerMask whatIsGround;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (GameManager.playPressed){
            AnimationControllers();
            CollisionChecks();
            FlipController();
            xInput = Input.GetAxisRaw("Horizontal");
            Movement();

            if (Input.GetKeyDown(KeyCode.Space)){
                Jump();
            }
        }
    }
    private void AnimationControllers(){
        anim.SetFloat("xVelocity",rb.velocity.x);
        anim.SetFloat("yVelocity",rb.velocity.y);
        anim.SetBool("isGrounded",isGrounded);
    }
    private void Jump(){
        if (isGrounded){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void FlipController(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x < transform.position.x && facingRight){
            Flip();
        }
        else if (mousePos.x > transform.position.x && !facingRight){
            Flip();
        }
    }
    private void Flip(){
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void Movement(){
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
    }
    private void CollisionChecks(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void OnDrawGizmos(){
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
    }
}
