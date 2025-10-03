using UnityEngine;

public class UIBallScript : MonoBehaviour
{
    //speed and rotation of uiBall
    [SerializeField] int rotateValue = 5;
    [SerializeField] float speed = 50;

    void Update()
    {
        //move ball to the right while rotating
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
        transform.Rotate(0, 0, rotateValue * Time.deltaTime);
    }
}
