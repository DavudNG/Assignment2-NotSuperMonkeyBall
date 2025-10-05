using System.Collections;
using UnityEngine;

/*
    PlayerMovement.cs     
    Co-Authors: James & David

    Desc: This script outlines the player's movement, and other functions that affect it.
*/
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
    private bool stopPlaying = false; // Bool to ensure only 1 walk sound plays at a single time

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D of the player to allow for movement functionality
    }

    void Start()
    {
        isFlipped = true;
    }
    
    /*
        James:
        I need this coroutine because if it is deleted then the walk sound will play 150 times every second
    */
    IEnumerator soundCoroutine()
    {
        stopPlaying = true; // Variable to ensure only 1 walking sound plays at a single time
        yield return new WaitForSeconds(0.6f); // Wait for 0.6 seconds between walking sounds because otherwise the sounds will overlap and not sound good
        stopPlaying = false; // Setting of the variable to false to let it be known that another walking sound can be played
    }

    private void Update()
    {
        // While the player is grounded and moving (aka key press) and the sound is not on cooldown then play another.
        if (this.isGrounded() && Input.anyKey && !stopPlaying)
        {
            SoundManager.PlaySound(SoundType.WALK); // Play the walk sound if a button is pressed while the character is grounded and a walk sound is not already playing
            StartCoroutine(soundCoroutine()); // Start the walk sound coroutine to ensure only 1 plays at a time
        }

        float move = Input.GetAxis("Horizontal");

        if (!knockedBack) // If not currently getting knocked back (getting knocked back disables movement for a time period)
        {
            movementInput = new Vector2(move, 0);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                SoundManager.PlaySound(SoundType.JUMP); // Play the jump sound when jumping
                body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
                StopParticleEffect();
                PlayParticleEffect();
            }

            myAnimator.SetFloat("speed", Mathf.Abs(movementInput.x));
            myAnimator.SetFloat("vertical_speed", body.linearVelocity.y);
            myAnimator.SetBool("grounded", isGrounded());
        }

        if (move > 0)
        {
            myRenderer.flipX = false;
            isFlipped = false;

        }
        else if (move < 0)
        {
            myRenderer.flipX = true;
            isFlipped = true;
        }
    }

    private void FixedUpdate()
    {
        if (movementInput.magnitude > 0 || movementInput.magnitude < 0)
            body.AddForce(movementInput * moveSpeed, ForceMode2D.Force);
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, raySize, 0, -transform.up, castDistance, groundLayer) || Physics2D.BoxCast(transform.position, raySize, 0, -transform.up, castDistance, interactableLayer))
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

    public void Explode(Vector2 force, float duration) // Public method that other objects can call on collision to trigger an "explosion"
    {
        StartCoroutine(ExplodeCoroutine(force, duration)); // Start the explosion coroutine to disable movement for a time period
    }

    private IEnumerator ExplodeCoroutine(Vector2 force, float duration) // Explosion coroutine called by the Explode method
    {
        knockedBack = true; // knockedBack set to true disables movement
        body.AddForce(force, ForceMode2D.Impulse); // Adds a force to the player to "explode" them away
        yield return new WaitForSeconds(duration); // Wait for a selected amount of time
        knockedBack = false; // Enable player movement again by setting knockedBack back to false after the time period has elapsed
    }

    public void OnCollisionEnter2D(Collision2D collision) // When the player collides with another object
    {
        SoundManager.PlaySound(SoundType.LAND); // Play the "land" sound effect (most of the time the player collides with something, it is the ground)
    }
}
