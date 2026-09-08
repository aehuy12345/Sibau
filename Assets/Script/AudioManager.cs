using UnityEngine;

public class AudioManager : MonoBehaviour 
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip shootClip;
    public AudioClip explosionClip;

    void Awake() 
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Phát âm thanh bắn đạn
    public void PlayShootSound() 
    {
        if (shootClip != null && audioSource != null) 
        {
            audioSource.PlayOneShot(shootClip);
        }
    }

    // Phát âm thanh nổ
    public void PlayExplosionSound() 
    {
        if (explosionClip != null && audioSource != null) 
        {
            audioSource.PlayOneShot(explosionClip);
        }
    }
}