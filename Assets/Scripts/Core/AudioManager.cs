using UnityEngine;
using RS;

public class AudioManager : PersistentSingleton<AudioManager>
{
    public AudioSource backgroundMusic;
    public AudioSource soundEffects;

    public void PlayBackgroundMusic(AudioClip clip)
    {
        backgroundMusic.clip = clip;
        backgroundMusic.Play();
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffects.PlayOneShot(clip);
    }

    public void StopBackgroundMusic()
    {
        backgroundMusic.Stop();
    }

    public void StopSoundEffects()
    {
        soundEffects.Stop();
    }

    public void SetBackgroundVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }
    
    public void SetSoundEffectsVolume(float volume)
    {
        soundEffects.volume = volume;
    }
}
