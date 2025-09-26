using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] public float moveSpeed;
    private float initialMoveSpeed;
    [SerializeField] public float jumpForce;
    private bool touchingGround = false;
    private float knockbackTimer;
    private bool knockedBack;

    private Vector2 movementInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        initialMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        if (!knockedBack)
        {
           //if (int.TryParse(ReadWrite.ReturnAttribute("isSlippery"), out _))
           //{
           //    float move = Input.GetAxisRaw("Horizontal");
           //    body.AddForce(new Vector2(move * int.Parse(ReadWrite.ReturnAttribute("isSlippery")), 0));
           //}
           // else
           // {
                float move = Input.GetAxis("Horizontal");
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
            if (Input.GetKeyDown(KeyCode.Space) && touchingGround == true)
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
                touchingGround = false;
            }
        }
    }

    private void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        //{
        //    body.AddForce(movementInput * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        //}

        if(movementInput.magnitude > 0 || movementInput.magnitude < 0)
            body.AddForce(movementInput * moveSpeed, ForceMode2D.Force);

        //if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        //{
        //    body.AddForce(movementInput * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        //}
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchingGround = true;
        }

        if (ReadWrite.CheckAttribute("isSlowed"))
        {
            moveSpeed = initialMoveSpeed / 4;
            Debug.Log("new movespeed: " + moveSpeed.ToString());
        }
        else
        {
            moveSpeed = initialMoveSpeed;
        }
    }
    
        private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchingGround = false;
        }
    }
}
