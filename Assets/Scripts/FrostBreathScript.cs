using UnityEngine;

public class FrostBreathScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //if ball enter collides with frost breath, freezes ball by checking the gameObject tag.
        if (collision.CompareTag("Ball"))
        {
            Ball ball = collision.GetComponent<Ball>();
            if (ball != null)
            {
                if (ball.Isfrozen() == false)
                {
                    ball.Freeze(3f);
                }   
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if ball stay collides with frost breath, freezes ball by checking the gameObject tag.
        if (collision.CompareTag("Ball"))
        {
            Ball ball = collision.GetComponent<Ball>();
            if (ball != null)
            {
                if (ball.Isfrozen() == false)
                {
                    ball.Freeze(3f);
                }
            }
        }
    }


}
