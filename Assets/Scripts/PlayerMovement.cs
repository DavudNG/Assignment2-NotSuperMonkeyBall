using System.Collections;
using UnityEngine;

/*
    PlayerMovement.cs     
    Author: David
    Co-Author: James (knockback code, sound code)

    Desc: This script handles the player's movement including collision checks, some particle, 
    animator and renderer logic related to the player and some unused knockback code.
*/
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; // Ref to the rigidbody of the player
    public float moveSpeed; // float movement speed of the player
    public float jumpForce; // float jump strength of the player
    private float knockbackTimer; 
    private bool knockedBack;

    public SpriteRenderer myRenderer; // Ref to renderer of the player
    public Animator myAnimator; // Ref to the Animator of the player
    public ParticleSystem myParticleSystem; // Ref to the particle of the player for jumping

    private Vector2 movementInput; // Vector 2 to store the movement input vector
    public Vector2 raySize; // size of the ray cast to use
    public float castDistance; // off set of the ray cast to use
    public LayerMask groundLayer; // ref to the groundlayer tag
    public LayerMask interactableLayer; // ref to the interactable layer tag
    public bool isFlipped; // bool to flag whether player is flipped
    public int emitCount; // emit count for the particle effect
    private bool stopPlaying = false; // bool for sounds playing

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>(); // grab the rigidbody ref
    }

    void Start()
    {
        isFlipped = true; // flip the player on start cauz monkey faces backwards
    }
    
    /*
        James:
        I need this coroutine because if it is deleted then the walk sound will play 150 times every second
    */
    IEnumerator soundCoroutine()
    {
        stopPlaying = true;
        yield return new WaitForSeconds(0.6f);
        stopPlaying = false;
    }

    // update function to update various logic each frame
    private void Update()
    {
        // While the player is grounded and moving (aka key press) and the sound is not on cooldown then play another.
        if (this.isGrounded() && Input.anyKey && !stopPlaying)
        {
            SoundManager.PlaySound(SoundType.WALK);
            StartCoroutine(soundCoroutine());
        }

        float move = Input.GetAxis("Horizontal"); // store the input axis vector

        if (!knockedBack) // redundant
        {
            movementInput = new Vector2(move, 0); // grab the x magnitude from move and create a new vector 2

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) // when space is pressed and the player is grounded
            {
                SoundManager.PlaySound(SoundType.JUMP);
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // add the jump force to the existing velocity
                StopParticleEffect(); // clear the particle effect
                PlayParticleEffect(); // play the particle effect emission
            }

            myAnimator.SetFloat("speed", Mathf.Abs(movementInput.x)); // sets the paramater in animation statemachine for the animation to play move
            myAnimator.SetFloat("vertical_speed", rb.linearVelocity.y); // sets the paramater in animation statemachine for the animation to play jump
            myAnimator.SetBool("grounded", isGrounded()); // sets the paramater in animation statemachine for the animation to return to idle
        }

        if (move > 0) // when move is larger than 0
        {
            myRenderer.flipX = false; // dont flip the sprite
            isFlipped = false; // set the flipped bool to false

        }
        else if (move < 0) // when move is less than 0
        {
            myRenderer.flipX = true; // flip the sprite
            isFlipped = true; // set the flipped bool to true
        }
    }

    // unity's fixed update irregardless of fps function
    private void FixedUpdate()
    {
        if (movementInput.magnitude > 0 || movementInput.magnitude < 0) // when the axis input magnitude isnt zero
            rb.AddForce(movementInput * moveSpeed, ForceMode2D.Force); // add the force 
    }

    /*
        isGrounded()   
        Author: David
        Desc: function to ray cast a box to check for whether the player is grounded
    */
    public bool isGrounded()
    {
        // checks whether the raycast returns true if it collides with either the groundlayer or interactable
        if (Physics2D.BoxCast(transform.position, raySize, 0, -transform.up, castDistance, groundLayer) || Physics2D.BoxCast(transform.position, raySize, 0, -transform.up, castDistance, interactableLayer))
        {
            // if true
            return true;
        }

        else
        {
            // if nothing
            return false;
        }
    }

    public bool GetFlipped() { return isFlipped; } // getter function for flipped status

    /*
        PlayParticleEffect()   
        Author: David
        Desc: function to call emit from the particle system
    */
    public void PlayParticleEffect() // function to call emit from the particle system
    {
        myParticleSystem.Emit(emitCount);
    }

    /*
        StopParticleEffect()   
        Author: David
        Desc: function to call stop from the particle system
    */
    public void StopParticleEffect() //function to call stop from the particle system
    {
        myParticleSystem.Stop();
    }

    /*
    OnDrawGizmos() 
    Debug gizmo drawing function for the collision check
    */
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, raySize);
    }


    // unused
    public void Explode(Vector2 force, float duration)
    {
        StartCoroutine(ExplodeCoroutine(force, duration));
    }

    // unused
    private IEnumerator ExplodeCoroutine(Vector2 force, float duration)
    {
        knockedBack = true;
        rb.AddForce(force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        knockedBack = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.PlaySound(SoundType.LAND);
    }
}
