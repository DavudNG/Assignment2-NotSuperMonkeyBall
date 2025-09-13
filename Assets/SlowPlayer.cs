using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour
{
    [SerializeField] public float slowAmount;

    private void OnCollisionStay2D(Collision2D collision)
    {
        ReadWrite.WriteAttribute("isSlowed", "1");
    }
}
