using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static float volume;

    /// <summary>
    /// Use Singleton
    ///</summary>
    public static SoundController Instance;
    private void Awake() { Instance = this; }

    public void Start() { LoadVolume(); }
        
    private void Update() { ChangeVolume(); }

    /// <summary>
    /// Play sound with name
    ///</summary>
    public void PlayThisSound(string clipName)
    {
        AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot((AudioClip)Resources.Load("Sounds/" + clipName, typeof(AudioClip)));
    }
        
    private void ChangeVolume() { AudioListener.volume = volume; }
        
    private void LoadVolume() { volume = PlayerPrefs.GetFloat("musicVolume"); }
    
    public void SaveVolume() { PlayerPrefs.SetFloat("musicVolume", volume); }
}