using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

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

    public SpriteRenderer myRenderer;
    private Coroutine _hitFlashCorotine;
    private Color origColor;
    public float flashTime;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ogConstraints = rb.constraints;
        origColor = myRenderer.color;
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

        CallHitFlash();
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

        CallHitFlash();
        isKicked = true;
    }

    public void CallHitFlash()
    {
        _hitFlashCorotine = StartCoroutine(hitFlasher());
    }

    private IEnumerator hitFlasher()
    {
        float elapsedTime = 0f;

        while (elapsedTime < flashTime)
        {
            elapsedTime += Time.deltaTime;

            Color lerpedColor = Color.Lerp(new Color(255, 144, 129), origColor, elapsedTime / flashTime);
            myRenderer.color = lerpedColor;
            yield return null;
        }
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
