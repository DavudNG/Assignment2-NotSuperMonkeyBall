using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ReadWrite.WriteAttribute("isSlowed", "false");
        ReadWrite.WriteAttribute("isSlippery", "false");
        ReadWrite.WriteAttribute("isMoonGrav", "false");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
