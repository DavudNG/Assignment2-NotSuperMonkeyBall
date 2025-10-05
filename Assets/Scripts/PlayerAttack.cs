using UnityEngine;

/*
    PlayerAttack.cs     
    Author: David
    Desc: This script handles the players attack and collision check logic, particle effects and rendering of thr attack animation.
*/
public class PlayerAttack : MonoBehaviour
{
    public PlayerMovement myPlayer; // Ref to the player 
    public Transform AttackHitbox; // Ref to the transform 
    public Animator myAnimator; // Ref to the animator of the attackanimation 
    public SpriteRenderer myRenderer; // Ref to the renderer of the attackanimation

    public bool isAttackReady; // Bool to check whether the player is ready to atk and to stop atks starting if it isnt

    private float attackCooldownCount; // The current attack cooldown timer
    public float attackCooldown; // The max attack cooldown timer
    
    public LayerMask InteractableLayer; // Reference to the target interactable layer to check for 
    public Vector2 raySize; // Vector2 box size to raycast
    public float castDistance; // Float that determines how far to start the cast from the origin
    public float fOffset; // Float that determines how much offset to add for the collision check
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttackReady) // check if atk ready is true
        {
            if (Input.GetKeyDown(KeyCode.Q)) // when Q is pressed
            {
                myRenderer.flipX = false; // flips the renderer back to default 
                myAnimator.SetBool("isKick", true); // sets the kick parameter to control the player animator statemachine
                isAttackReady = false; // set flag for atk ready to false
            }

            if (Input.GetKeyDown(KeyCode.E)) // When E is pressed 
            {
                myAnimator.SetBool("isUppercut", true); // sets the uppercut parameter to control the player animator statemachine
                isAttackReady = false; // set flag for atk ready to false
            }
        }


        if (attackCooldownCount <= 0) // if the atk cooldown is 0 or less
        {
            isAttackReady = true; // flag that atk is ready
        }
        else // otherwise decrement the timer
        {
            attackCooldownCount -= Time.deltaTime; // decrement the count 
        }
    }

    /*
        Attack() 
        Author: David
        Desc: function for the kick action, sets the flag for animator state and ray casts forward or backward based on facing, 
        calls the kick function on objects hit with the raycast if any. 
    */
    public void Attack()
    {
        RaycastHit2D attackTest; // make a list of things hit by the raycast 

        myAnimator.SetBool("isKick", false);  // set the animator's kick parameter back to false to exit the animation

        //note: could refactor this to check in front of the player only if the movement script was changed to
        //      actually rotate the player facing and not just the sprite

        if (myPlayer.GetFlipped() == false) // if the player isnt flipped
        {
            this.transform.position = new Vector2(AttackHitbox.position.x + fOffset, this.transform.position.y); // change the location of the ray cast box origin
            attackTest = Physics2D.BoxCast(new Vector2(AttackHitbox.position.x + fOffset, AttackHitbox.position.y), raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer); // ray cast backward and store the result
        }

        else // otherwise it is flipped then
        {
            this.transform.position = new Vector2(AttackHitbox.position.x , this.transform.position.y); // change the location of the ray cast box origin
            myRenderer.flipX = true; // flip the sprite
            attackTest = Physics2D.BoxCast(AttackHitbox.position, raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer); // ray cast forward and store the result 
        }
            
        if(attackTest.collider != null) // when the list isnt empty
        {
            attackTest.collider.GetComponent<Ball>().Kick(myPlayer.GetFlipped()); //call kick method from objects in the list
        }
        attackCooldownCount = attackCooldown; // set the cooldown count to the max cooldown 
    }

    /*
        Attack2() 
        Author: David
        Desc: function for the launch action, sets the animator parameter, checks whether the player is flipped, performs a ray cast and 
        calls launch on objects hit.
    */
    public void Attack2()
    {
        RaycastHit2D attackTest; // make a list of things hit by the raycast 
        myAnimator.SetBool("isUppercut", false); // set the animator's uppercut flag to false to exit the animation

        //note: could refactor this to check in front of the player only if the movement script was changed to
        //      actually rotate the player facing and not just the sprite.
        if (myPlayer.GetFlipped() == false) // if the player isnt flipped
        {
            this.transform.position = new Vector2(AttackHitbox.position.x + fOffset, this.transform.position.y); // change the location of the ray cast box origin
            myRenderer.flipX = false; // set the attack animation renderer's flip flag to false
            attackTest = Physics2D.BoxCast(new Vector2(AttackHitbox.position.x + fOffset, AttackHitbox.position.y), raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer); // ray cast backward and store the result
        }

        else // otherwise it is flipped then
        {
            this.transform.position = new Vector2(AttackHitbox.position.x, this.transform.position.y); // change the location of the ray cast box origin back to normal
            myRenderer.flipX = true; // // set the attack animation renderer's flip flag to false
            attackTest = Physics2D.BoxCast(AttackHitbox.position, raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer); // ray cast forward and store the result
        }

        if (attackTest.collider != null) // when the list isnt empty 
        {
            attackTest.collider.GetComponent<Ball>().Launch(myPlayer.GetFlipped()); // call launch method from objects in the list
        }
        attackCooldownCount = attackCooldown; // reset the cooldown to max
    }


    // quick OnDrawGizmo function to check the sizes of the raycasts 
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(AttackHitbox.position - AttackHitbox.forward * castDistance, raySize); 
        Gizmos.DrawWireCube(new Vector3(AttackHitbox.position.x + fOffset, AttackHitbox.position.y,1) - AttackHitbox.forward * castDistance, raySize);
    }
}
