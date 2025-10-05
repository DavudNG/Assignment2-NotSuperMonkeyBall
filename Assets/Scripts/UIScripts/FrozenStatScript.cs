using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FrozenStatScript : MonoBehaviour
{
    public Image img;
    public TextMeshProUGUI txt;
    public Ball ball;
    
    void Start()
    {
        img.enabled = false;
        txt.enabled = false;
    }


    void Update()
    {
        if (ball.frozen == true)
        {
            img.enabled = true;
            txt.enabled = true;
        }
        else
        {
            img.enabled = false;
            txt.enabled = false;
        }
    }
}
