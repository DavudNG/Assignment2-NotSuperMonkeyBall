using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SlipPlayer : MonoBehaviour
{
    [SerializeField] public float slipperiness;

    private void OnCollisionStay2D(Collision2D collision)
    {
        ReadWrite.WriteAttribute("isSlippery", slipperiness.ToString());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ReadWrite.WriteAttribute("isSlippery", slipperiness.ToString());
    }
}
