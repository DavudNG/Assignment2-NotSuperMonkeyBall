using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ReadWrite.WriteAttribute("isSlowed", "false"); // Set the textfile attributes to false as the player on spawn will not be affected by anything as they have not done anything
        ReadWrite.WriteAttribute("isSlippery", "false"); // Set the textfile attributes to false as the player on spawn will not be affected by anything as they have not done anything
        ReadWrite.WriteAttribute("isMoonGrav", "false"); // Set the textfile attributes to false as the player on spawn will not be affected by anything as they have not done anythings
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
