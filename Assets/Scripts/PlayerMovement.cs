using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] public float moveSpeed;
    private float initialMoveSpeed;
    [SerializeField] public float jumpForce;
    //public bool touchingGround = false;
    public bool debugGroundCheck;
    private float knockbackTimer;
    private bool knockedBack;

    public SpriteRenderer myRenderer;
    public Animator myAnimator;
    private Vector2 movementInput;
    public Vector2 raySize;
    public float castDistance;
    public LayerMask groundLayer;
    public LayerMask interactableLayer;
    public bool isFlipped;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        initialMoveSpeed = moveSpeed;
        isFlipped = true;
    }

    private void Update()
    {
        float move = Input.GetAxis("Horizontal");
        
        if (!knockedBack)
        {
           //if (int.TryParse(ReadWrite.ReturnAttribute("isSlippery"), out _))
           //{
           //    float move = Input.GetAxisRaw("Horizontal");
           //    body.AddForce(new Vector2(move * int.Parse(ReadWrite.ReturnAttribute("isSlippery")), 0));
           //}
           // else
           // {
                
                //body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, body.linearVelocity.y);

                //if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                //{
                //    movementInput = new Vector2(moveSpeed,0);
                //}
                //
                //if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                //{
                //    // body.AddForce(new Vector2(-moveSpeed, 0), ForceMode2D.Force);
                //    movementInput = new Vector2(-moveSpeed,0);
                //}
                movementInput = new Vector2(move, 0);
                
           // }
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
                //touchingGround = false;
            }

            myAnimator.SetFloat("speed", Mathf.Abs(movementInput.x));
            myAnimator.SetFloat("vertical_speed", body.linearVelocity.y);
            myAnimator.SetBool("grounded", isGrounded());
            debugGroundCheck = isGrounded();
        }
        
        if(move > 0)
        {
            myRenderer.flipX = false;
            isFlipped = false;

        }
        else if(move < 0)
        {
            myRenderer.flipX = true;
            isFlipped = true;
        }
    }

    private void FixedUpdate()
    {
        if(movementInput.magnitude > 0 || movementInput.magnitude < 0)
            body.AddForce(movementInput * moveSpeed, ForceMode2D.Force);
    }

    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, raySize, 0, -transform.up, castDistance, groundLayer) || Physics2D.BoxCast(transform.position, raySize, 0, -transform.up, castDistance, interactableLayer))
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, raySize);
    }

    public void Explode(Vector2 force, float duration)
    {
        StartCoroutine(ExplodeCoroutine(force, duration));
    }

    private IEnumerator ExplodeCoroutine(Vector2 force, float duration)
    {
        knockedBack = true;
        body.AddForce(force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        knockedBack = false;
    }

    public bool getFlipped() { return isFlipped; }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Ball"))
    //    {
    //        touchingGround = true;
    //    }

    //    if (ReadWrite.CheckAttribute("isSlowed"))
    //    {
    //        moveSpeed = initialMoveSpeed / 4;
    //        Debug.Log("new movespeed: " + moveSpeed.ToString());
    //    }
    //    else
    //    {
    //        moveSpeed = initialMoveSpeed;
    //    }
    //}
    
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Ball"))
    //    {
    //        touchingGround = false;
    //    }
    //} 
}
