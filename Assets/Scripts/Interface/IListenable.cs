using UnityEngine;

public interface IListenable
{
    AudioClip AudioClip { get; }
    AudioSource AudioSource { get; }
    bool AutoPlay { get; }
    bool Loop { get; }

    void InitAudioSource();
    void Play();
    void Stop();
}
