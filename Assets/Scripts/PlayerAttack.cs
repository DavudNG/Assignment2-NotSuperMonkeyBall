using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerMovement myPlayer;
    public Transform AttackHitbox;
    public Animator myAnimator;
    public SpriteRenderer myRenderer;

    public bool isAttacking;
    public bool isAttackReady;

    public float attackCooldownCount;
    public float attackCooldown;
    
    public float attackTimer;
    public float attackTimerMax;

    public LayerMask InteractableLayer;
    public Vector2 raySize;
    public float castDistance;
    public float fOffset;
    

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
