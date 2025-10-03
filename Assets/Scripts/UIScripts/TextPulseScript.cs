using System;
using UnityEngine;
using UnityEngine.UI;

public class TextPulseScript : MonoBehaviour
{
    //properties for text pulse, how long each pulse lasts, how big and how small text gets.
    public float pulseSpeed = 2f;
    public float minScale = 0.95f;
    public float maxScale = 1.05f;

    private Vector3 originalScale;
    private float time;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        //pulses text based on delta time and specific scale inputed
        time += Time.deltaTime * pulseSpeed;
        float scale = Mathf.Lerp(minScale, maxScale, (MathF.Sin(time) + 1f) / 2f);
        transform.localScale = originalScale * scale;
    }
}
