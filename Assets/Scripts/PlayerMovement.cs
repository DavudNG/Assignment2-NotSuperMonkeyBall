using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, body.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && touchingGround == true)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            touchingGround = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (ReadWrite.CheckAttribute("isSlowed"))
            {
                moveSpeed = initialMoveSpeed / 4;
                Debug.Log("new movespeed: " + moveSpeed.ToString());
            }
            else
            {
                moveSpeed = initialMoveSpeed;
            }
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (ReadWrite.CheckAttribute("isSlowed"))
            {
                moveSpeed = initialMoveSpeed / 4;
                Debug.Log("new movespeed: " + moveSpeed.ToString());
            }
            else
            {
                moveSpeed = initialMoveSpeed;
            }
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchingGround = true;
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
