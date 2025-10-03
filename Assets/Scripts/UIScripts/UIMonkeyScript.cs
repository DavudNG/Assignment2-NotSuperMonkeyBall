using Unity.Mathematics;
using UnityEngine;

public class UIMonkeyScript : MonoBehaviour
{
    //has ball object as variable to allow both sprites to move at same time/speed/starting position
    [SerializeField] public GameObject ball;
    [SerializeField] float speed = 200;
    public Vector3 startPos = new Vector3(-170, 360, 0);
    public Vector3 ballStartPos = new Vector3(-100, 360, 0);


    void Start()
    {
        //sets uiBall and uiMonkey starting position
        transform.position = startPos;
        ball.transform.position = ballStartPos;
    }
    void Update()
    {
        //moves monkey to the right
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if monkey collides with Despawner, changes monkey + ball position to start position
        // which loops the "animation"
        if (collision.gameObject.tag == "Despawner")
        {
            gameObject.transform.position = startPos;
            ball.transform.position = ballStartPos;
            gameObject.transform.Rotate(0, 0, 0);
        }
    }
}
