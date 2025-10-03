using NUnit.Framework;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    //bool to check if ball is frozen and for how long..
    private bool frozen = false;
    private float frozenTime = 0f;

    private RigidbodyConstraints2D ogConstraints;

    public bool isLaunched;
    public bool isKicked;
    public bool isReversed;
    public float kickStrength;
    public float launchStrength;
    public float torqueStr;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ogConstraints = rb.constraints;

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
        if(isKicked)
        {
            if(isReversed)
            {
                this.rb.AddForce(new Vector2(-kickStrength, 0), ForceMode2D.Force);
            }
            else
            {
                this.rb.AddForce(new Vector2(kickStrength, 0), ForceMode2D.Force);
            }
                
            isKicked = false;
            Debug.Log(isKicked);
        }

        if (isLaunched)
        {
            
            if (isReversed)
            {
                this.rb.AddForce(new Vector2(-kickStrength, launchStrength), ForceMode2D.Force);
                this.rb.AddTorque(-torqueStr);
            }
            else
            {
                this.rb.AddForce(new Vector2(kickStrength, launchStrength), ForceMode2D.Force);
                this.rb.AddTorque(torqueStr);
            }

            isLaunched = false;
        }
    }

    public void Launch(bool reversed)
    {
        if (reversed)
        {
            isReversed = true;
        }
        else 
        { 
            isReversed = false; 
        }

        isLaunched = true;
    }

    public void Kick(bool reversed)
    {
        if (reversed)
        {
            isReversed = true;
        }
        else
        {
            isReversed = false;
        }

        isKicked = true;
        
    }

    //method to freeze ball
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

    //method to unfreeze ball
    private void Unfreeze()
    {
        frozen = false;

        rb.constraints = ogConstraints;
    }
}
