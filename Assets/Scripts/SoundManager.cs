using UnityEngine;


/*
    SoundManager.cs
    Author: James
    Desc: This script manages all the sounds in the game, allowing other objects to play a sound using the "PlaySound" function
*/

// The order of the variables in the enum must match the order in the serialized field
public enum SoundType // Enum to store the sounds being used
{
    JUMP,
    EXPLOSION,
    HIT,
    WIN,
    WALK,
    BOUNCE,
    DEATH,
    ENEMY,
    LAND,
    LAUNCH,

    LEVEL1MUSIC,
    LEVEL2MUSIC,
    LEVEL3MUSIC,

    MENUMUSIC,
    HURT
}
[RequireComponent(typeof(AudioSource))] // Require an audio source component to play the sounds
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance; // Variable to store this
    private AudioSource audioSource; // Variable to store the audio source
    [SerializeField] private AudioClip[] soundList; // Array to store all the sounds in the game

    private void Awake() // When in use
    {
        instance = this; // Get this
        audioSource = GetComponent<AudioSource>(); // Get the audio source
    }

    private void Start()
    {
    
    } 

    public static void PlaySound(SoundType sound, float volume = 1) // Play the sound specified in the parameter at a volume specified in the parameter (or at 100% volume if left unspecified)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume); // Uses the audio source to play the sound specified at the volume specified 1 time.
    }
}
