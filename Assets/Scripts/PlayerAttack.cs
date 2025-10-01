using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerMovement myPlayer;
    public Transform AttackHitbox;
    
    public bool isAttacking;
    public bool isAttackReady;

    public float attackCooldownCount;
    public float attackCooldown;
    
    public float attackTimer;
    public float attackTimerMax;

    public LayerMask InteractableLayer;
    public Vector2 raySize;
    public float castDistance;

    private Vector2 myFacing;
    public float fOffset;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack2();
            Debug.Log("isLaunching");
        }

        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;
        }

        if (attackTimer <= 0)
        {
            isAttacking = false;
        }

        if (attackCooldownCount <= attackCooldown && !isAttacking)
        {
            isAttackReady = true;
        }


    }

    public void Attack()
    {
        if (isAttackReady)
        {
            RaycastHit2D attackTest;
            attackTimer = attackTimerMax;
            isAttacking = true;
            
            if(myPlayer.getFlipped() == false)
            {
                //attackTest = Physics2D.BoxCast(AttackHitbox.position, raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer);
                attackTest = Physics2D.BoxCast(new Vector2(AttackHitbox.position.x + fOffset, AttackHitbox.position.y), raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer);
            }
            
            else
            {
                //attackTest = Physics2D.BoxCast(new Vector2 (AttackHitbox.position.x + fOffset, AttackHitbox.position.y), raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer);
                attackTest = Physics2D.BoxCast(AttackHitbox.position, raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer);
            }
                
            if(attackTest.collider != null)
            {
                attackTest.collider.GetComponent<Ball>().Kick(myPlayer.getFlipped());
                Debug.Log("isAttacking");
            }
            isAttackReady = false;
        }
    }

    public void Attack2()
    {
        if (isAttackReady)
        {
            RaycastHit2D attackTest;
            attackTimer = attackTimerMax;
            isAttacking = true;

            if (myPlayer.getFlipped() == false)
            {
                //attackTest = Physics2D.BoxCast(AttackHitbox.position, raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer);
                attackTest = Physics2D.BoxCast(new Vector2(AttackHitbox.position.x + fOffset, AttackHitbox.position.y), raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer);
            }

            else
            {
                //attackTest = Physics2D.BoxCast(new Vector2 (AttackHitbox.position.x + fOffset, AttackHitbox.position.y), raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer);
                attackTest = Physics2D.BoxCast(AttackHitbox.position, raySize, 0, AttackHitbox.forward, castDistance, InteractableLayer);
            }

            if (attackTest.collider != null)
            {
                attackTest.collider.GetComponent<Ball>().Launch(myPlayer.getFlipped());
            }
            isAttackReady = false;
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(AttackHitbox.position - AttackHitbox.forward * castDistance, raySize);
        Gizmos.DrawWireCube(new Vector3(AttackHitbox.position.x + fOffset, AttackHitbox.position.y,1) - AttackHitbox.forward * castDistance, raySize);
    }
}
