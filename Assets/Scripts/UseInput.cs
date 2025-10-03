using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UseInput : MonoBehaviour
{
    // Start is called before the first frame update
    private string input;
    public TextMeshProUGUI Welcome;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadInput(string s)
    {
        input = s;
        Debug.Log(input);
        Welcome.text = "Welcome " + input;
    }
}
