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
            if (int.TryParse(ReadWrite.ReturnAttribute("isSlippery"), out _))
            {
                float move = Input.GetAxisRaw("Horizontal");
                body.AddForce(new Vector2(move * int.Parse(ReadWrite.ReturnAttribute("isSlippery")), 0));
            }
            else
            {
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, body.velocity.y);

                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && touchingGround == true)
            {
                body.velocity = new Vector2(body.velocity.x, jumpForce);
                touchingGround = false;
            }
        }
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
