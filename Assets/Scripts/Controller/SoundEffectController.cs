using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

// Agregamos un componente obligatorio -> Esto fueza a que unity agregue 
// el componente si no existe en el objeto.
[RequireComponent(typeof(AudioSource))]
public class SoundEffectController : MonoBehaviour, IListenable
{
    #region IListenable_Properties

    public AudioClip AudioClip => _soundTrackClip;
    /// SerializeField nos permite exponer una propiedad privada en el inspector
    [SerializeField] private AudioClip _soundTrackClip;
    [SerializeField] private AudioClip _victoryClip;
    [SerializeField] private AudioClip _defeatClip;
    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;
    #endregion

    #region IListenable_Methods
    public void InitAudioSource()
    {
        // Asignar el componente AudioSource
        _audioSource = GetComponent<AudioSource>();
        // Asignamos el audio clip al AudioSource
        _audioSource.clip = AudioClip;
    }

    // Reproducir de esta manera evita tener que asignar un clip al source
    public void PlayOnShot(AudioClip clip) => AudioSource.PlayOneShot(clip);

    // Esta reproducci�n necesita tener que asignar un clip al source
    public void Play() => AudioSource.Play();

    // Detiene un clip si esta asignado y en reproducci�n
    public void Stop() => AudioSource.Stop();
    #endregion

    #region Unity_Events

    void Start()
    {
        InitAudioSource();
        Play();
        EventsManager.instance.OnGameOver += OnGameOver;
    }
    #endregion
    
    #region GameOver
    
    private void OnGameOver(bool isVictory)
    {
        if (isVictory) PlayOnShot(_victoryClip); //VictoryTheme
        else           PlayOnShot(_defeatClip); //DefeatTheme
    }
    
    #endregion
    
}
