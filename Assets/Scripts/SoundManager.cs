using UnityEngine;

// The order of the variables in the enum must match the order in the serialized field
public enum SoundType
{
    JUMP,
    EXPLOSION,
    HIT,
    WIN,
    WALK,
    BOUNCE,
    DEATH,
    ENEMY,
    LAND
}
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] soundList;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
    
    } 

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }
}
