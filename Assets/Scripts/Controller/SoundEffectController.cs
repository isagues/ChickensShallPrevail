using System;
using UnityEngine;

// Agregamos un componente obligatorio -> Esto fueza a que unity agregue 
// el componente si no existe en el objeto.
namespace Controller
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEffectController : MonoBehaviour, IListenable
    {
        public AudioClip AudioClip => soundTrackClip;
        public bool AutoPlay => autoplay;
        public bool Loop => loop;
        public void SetAudioClip(AudioClip clip) => soundTrackClip = clip;
        public AudioSource AudioSource => _audioSource;
    
        [SerializeField] private AudioClip soundTrackClip;
        [SerializeField] private bool autoplay;
        [SerializeField] private bool loop;
        private AudioSource _audioSource;
        
        protected virtual void Start()
        {
            InitAudioSource();
            if (autoplay)
            {
                Play();
            }
        }
        
        public void InitAudioSource()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = AudioClip;
            _audioSource.loop = loop;
        }
    
        public void Play() => AudioSource.Play();
        public void Stop() => AudioSource.Stop();
    }
}
