using UnityEngine;

public class Toggle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("DyslexiaFont is " + PlayerPrefs.GetInt("DyslexiaFont", 0));
        if (PlayerPrefs.GetInt("DyslexiaFont", 0) != 1)
        {
            GetComponent<UnityEngine.UI.Toggle>().isOn = true;
        }
        else
        {
            GetComponent<UnityEngine.UI.Toggle>().isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
