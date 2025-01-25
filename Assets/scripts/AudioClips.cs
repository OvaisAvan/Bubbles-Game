using UnityEngine;

public class AudioClips : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip AudioClip;

    public static AudioClips instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayBubbleEffect()
    {
        if (AudioSource != null && AudioClip != null)
        {
            AudioSource.PlayOneShot(AudioClip);
        }
    }
}