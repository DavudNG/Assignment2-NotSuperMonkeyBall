using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ParentEnemy : MonoBehaviour
{
    public enum MovementType { backNForth, followPlayer };
    [SerializeField] private MovementType movementType;
    [SerializeField] private float BNF_speed;
    [SerializeField] private float BNF_time;
    private bool colliding;
    public Transform player;

    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (movementType == MovementType.backNForth)
        {
            StartCoroutine(BackAndForth());
        }
        else if (movementType == MovementType.followPlayer)
        {
            StartCoroutine(FollowPlayer());
        }
    }
    private IEnumerator FollowPlayer()
    {
        while (true)
        {
            Vector3 direction = player.position - transform.position;
            body.velocity = new Vector2(direction.x, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator BackAndForth()
    {
        while (true)
        {
            body.velocity = new Vector2(-BNF_speed, body.velocity.y);
            yield return new WaitForSeconds(BNF_time);
            body.velocity = new Vector2(BNF_speed, body.velocity.y);
            yield return new WaitForSeconds(BNF_time);
        }
    }
}
