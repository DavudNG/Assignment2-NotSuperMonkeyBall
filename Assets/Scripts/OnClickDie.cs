using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickDie : MonoBehaviour
{
    // Start is called before the first frame update

    public SceneController sceneController;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        sceneController.LoadScene(2);
    }
}
