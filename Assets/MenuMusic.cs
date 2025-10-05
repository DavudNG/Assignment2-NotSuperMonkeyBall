using System.Collections;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool stopPlaying = false;
    void Start()
    {
    }
    IEnumerator soundCoroutine()
    {
        stopPlaying = true;
        yield return new WaitForSeconds(68f);
        stopPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopPlaying)
        {
            SoundManager.PlaySound(SoundType.MENUMUSIC);
            StartCoroutine(soundCoroutine());
        }
    }
}
