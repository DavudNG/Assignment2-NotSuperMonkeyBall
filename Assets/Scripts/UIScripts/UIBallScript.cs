using UnityEngine;

public class UIBallScript : MonoBehaviour
{
    [SerializeField] int rotateValue = 5;
    [SerializeField] float speed = 50;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
        transform.Rotate(0, 0, rotateValue * Time.deltaTime);
    }
}
