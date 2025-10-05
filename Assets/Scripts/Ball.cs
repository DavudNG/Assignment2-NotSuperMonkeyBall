using NUnit.Framework;
using System.Collections;
using UnityEngine;

/*
    Ball.cs     
    Author: David
    Co-Author: Julian 

    Desc: This script handles the ball's logic such as when it is hit 
        by the player, the hitflash and being frozen
*/
public class Ball : MonoBehaviour
{
    private Rigidbody2D rb; // Ref to the rigidbody of the ball
    //bool to check if ball is frozen and for how long..
    private bool frozen = false;
    private float frozenTime = 0f;

    private RigidbodyConstraints2D ogConstraints;

    // Ball logic variables
    private bool isLaunched; // bool to denote when the ball is launched 
    private bool isKicked; // bool to denote when the ball is kicked state
    private bool isReversed; // bool to denote when the direction of the ball's movement is flipped
    public float kickStrength; // float to determine how much force to add to the ball
    public float launchStrength; // float to determine how much launch force to add to the ball
    public float torqueStr; // float to determine how much torque to add to the ball

    // Hitflash variables
    public SpriteRenderer myRenderer; // Ref to the renderer of the ball
    private Coroutine _hitFlashCorotine; // Ref to the hitflash coroutine 
    private Color origColor; // To store the original color of the player
    public float flashTime; // Float that denotes the duration of the flash

    // On Start setup the references and original values  
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); // grab the rigidbody 2d off this object
        ogConstraints = rb.constraints;
        origColor = myRenderer.color; // grab the original colour
    }


    void Update()
    {
        //if the ball is frozen, stays frozen for set time. After time is up it unfreezes.
        if (frozen)
        {
            frozenTime -= Time.deltaTime;
            if (frozenTime <= 0)
            {
                Unfreeze();
            }
        }
    }

    private void FixedUpdate()
    {
        // logic for when the ball is in kicked state
        if(isKicked) // when kicked state is true
        {
            if(isReversed) // check if direction needs to be reversed 
            {
                this.rb.AddForce(new Vector2(-kickStrength, 0), ForceMode2D.Force); // apply backward force to the ball according to kick str
            }
            else // otherwise apply the force forward
            {
                this.rb.AddForce(new Vector2(kickStrength, 0), ForceMode2D.Force); // apply forward force to the ball according to kick str
            }
                
            isKicked = false; // reset the kicked state
        }

        // logic for when the ball is in launched state
        if (isLaunched) // when launched state is true
        {
            
            if (isReversed) // check if direction needs to be reversed
            {
                this.rb.AddForce(new Vector2(-kickStrength, launchStrength), ForceMode2D.Force); // apply backward force to the ball according to kick str and upwards force according to launch str 
                this.rb.AddTorque(-torqueStr); // apply torque to make the ball rotate backwards
            }
            else // otherwise apply the launch force forward
            {
                this.rb.AddForce(new Vector2(kickStrength, launchStrength), ForceMode2D.Force); // apply forward force to the ball according to kick str and upwards force according to launch str 
                this.rb.AddTorque(torqueStr); // apply torque to make the ball rotate forwards
            }

            isLaunched = false; // reset the launched state
        }
    }

    /*
    Launch(bool reversed) 
    Author: David
    Desc: public function to call when we want the ball to be launched, makes the ball flash, checks and sets if the direction is reversed according to the paramater 
            bool and sets the ball into launch state 
    */
    public void Launch(bool reversed)
    {
        isReversed = reversed; // Update the reversed with the parameter
        CallHitFlash(); // Call hitflash 
        isLaunched = true; // Set the launched flag to true
    }

    /*
        Kick(bool reversed) 
        Author: David
         Desc: public function to call when we want the ball to be kicked, makes the ball flash, checks and sets if the direction is reversed according to the paramater 
            bool and sets the ball into kicked state 
    */
    public void Kick(bool reversed)
    {
        isReversed = reversed; // Update the reversed with the parameter
        CallHitFlash(); // Call hitflash 
        isKicked = true; // Set the kicked flag to true
    }

    /*
        CallHitFlash() 
        Author: David
        Desc: Calls the hitFlasher coroutine on demand
    */
    public void CallHitFlash()
    {
        _hitFlashCorotine = StartCoroutine(HitFlasher()); // starts the coroutine and sets the reference to it
    }
    
    /*
        HitFlasher() 
        Author: David
        Desc: IEnumerator that lerps(linear interpolation: smooth transition between 2 points) 
        the renderer's colour values for a duration of time equal to flashtime
    */
    private IEnumerator HitFlasher()
    {
        float elapsedTime = 0f; // float to hold the current elapsed time

        while (elapsedTime < flashTime) // while the elapsed time doesnt exceed the flashtime
        {
            elapsedTime += Time.deltaTime; // increment the elapsed time

            Color lerpedColor = Color.Lerp(new Color(255, 144, 129), origColor, elapsedTime / flashTime); // lerp the colour value from the intended colour back to the original color  
            myRenderer.color = lerpedColor; // set the renderer's color each time to transition the color for the hit effect 
            yield return null; // pause the coroutine for a single frame with yield return null
        }
    }

    /*
       Freeze() 
       Author: Julian
       Desc: method to freeze ball
    */
    public void Freeze(float time)
    {
        //method sets ball velocity to 0 so it cant move for a short period.
        if (frozen) return;

        frozen = true;
        frozenTime = time;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    /*
        Unfreeze() 
        Author: Julian
        Desc: method to unfreeze ball
    */
    private void Unfreeze()
    {
        frozen = false;

        rb.constraints = ogConstraints;
    }
}
