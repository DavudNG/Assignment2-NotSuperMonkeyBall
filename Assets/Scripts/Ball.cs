using NUnit.Framework;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool frozen = false;
    private float frozenTime = 0f;

    private RigidbodyConstraints2D ogConstraints;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ogConstraints = rb.constraints;

    }


    void Update()
    {
        if (frozen)
        {
            frozenTime -= Time.deltaTime;
            if (frozenTime <= 0)
            {
                Unfreeze();
            }
        }
    }

    public void Freeze(float time)
    {
        if (frozen) return;

        frozen = true;
        frozenTime = time;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void Unfreeze()
    {
        frozen = false;

        rb.constraints = ogConstraints;
    }
}
