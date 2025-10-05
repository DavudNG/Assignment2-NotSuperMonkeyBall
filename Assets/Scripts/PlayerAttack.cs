using UnityEngine;

/*
    PlayerAttack.cs     
    Author: David

    Desc: This script handles the ball's logic such as when it is hit 
        by the player, the hitflash and being frozen
*/
public class PlayerAttack : MonoBehaviour
{
    public PlayerMovement myPlayer; // Ref to the player 
    public Transform AttackHitbox; // Ref to the transform 
    public Animator myAnimator; // Ref to the animator of the ball 
    public SpriteRenderer myRenderer; // Ref to the renderer of the ball

    public bool isAttackReady; // Bool to check whether the player is ready to atk and to stop atks starting if it isnt

    public float attackCooldownCount; // 
    public float attackCooldown; // 
    
    public float attackTimer; // 
    public float attackTimerMax; // 

    public LayerMask InteractableLayer; // 
    public Vector2 raySize; // 
    public float castDistance; // float that determines how far to cast 
    public float fOffset; // float that determines how much offset to add for the collision check
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttackReady)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                myRenderer.flipX = false;
                myAnimator.SetBool("isKick", true);
                isAttackReady = false;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                myAnimator.SetBool("isUppercut", true);
                isAttackReady = false;
            }
        }


        if (attackCooldownCount <= 0)
        {
            isAttackReady = true;
        }
        else
        {
            attackCooldownCount -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        RaycastHit2D attackTest;
        attackTimer = attackTimerMax;

        myAnimator.SetBool("isKick", false);
        if (myPlayer.GetFlipped() == false)
        {
            this.transform.position = new Vector2(AttackHitbox.position.x + fOffset, this.transform.position.y);
            attackTest = Physics2D.BoxCast(new Vector2(AttackHitbox.position.x + fOffset, AttackHitbox.position.y), raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer);
        }
        
        else
        {
            this.transform.position = new Vector2(AttackHitbox.position.x , this.transform.position.y);
            myRenderer.flipX = true;
            attackTest = Physics2D.BoxCast(AttackHitbox.position, raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer);
        }
            
        if(attackTest.collider != null)
        {
            attackTest.collider.GetComponent<Ball>().Kick(myPlayer.GetFlipped());
        }
        attackCooldownCount = attackCooldown;
    }

    public void Attack2()
    {
        RaycastHit2D attackTest;
        attackTimer = attackTimerMax;
        myAnimator.SetBool("isUppercut", false);

        if (myPlayer.GetFlipped() == false)
        {
            this.transform.position = new Vector2(AttackHitbox.position.x + fOffset, this.transform.position.y);
            myRenderer.flipX = false;
            attackTest = Physics2D.BoxCast(new Vector2(AttackHitbox.position.x + fOffset, AttackHitbox.position.y), raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer);
        }

        else
        {
            this.transform.position = new Vector2(AttackHitbox.position.x, this.transform.position.y);
            myRenderer.flipX = true;
            attackTest = Physics2D.BoxCast(AttackHitbox.position, raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer);
        }

        if (attackTest.collider != null)
        {
            attackTest.collider.GetComponent<Ball>().Launch(myPlayer.GetFlipped());
        }
        attackCooldownCount = attackCooldown;
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(AttackHitbox.position - AttackHitbox.forward * castDistance, raySize); 
        Gizmos.DrawWireCube(new Vector3(AttackHitbox.position.x + fOffset, AttackHitbox.position.y,1) - AttackHitbox.forward * castDistance, raySize);
    }
}
