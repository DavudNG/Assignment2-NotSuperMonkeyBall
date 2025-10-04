using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeed;
    public float jumpForce;
    private float knockbackTimer;
    private bool knockedBack;

    public SpriteRenderer myRenderer;
    public Animator myAnimator;
    public ParticleSystem myParticleSystem;

    private Vector2 movementInput;
    public Vector2 raySize;
    public float castDistance;
    public LayerMask groundLayer;
    public LayerMask interactableLayer;
    public bool isFlipped;
    public int emitCount;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        isFlipped = true;
    }

    private void Update()
    {
        float move = Input.GetAxis("Horizontal");
        
        if (!knockedBack)
        {
            movementInput = new Vector2(move, 0);
                
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
                StopParticleEffect();
                PlayParticleEffect();
            }

            myAnimator.SetFloat("speed", Mathf.Abs(movementInput.x));
            myAnimator.SetFloat("vertical_speed", body.linearVelocity.y);
            myAnimator.SetBool("grounded", isGrounded());
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

    public bool GetFlipped() { return isFlipped; }

    public void PlayParticleEffect()
    {
        //if(isGrounded())
            myParticleSystem.Emit(emitCount);
    }

    public void StopParticleEffect()
    {
        myParticleSystem.Stop();
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
}
