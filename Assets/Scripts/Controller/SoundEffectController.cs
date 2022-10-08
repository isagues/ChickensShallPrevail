using UnityEngine;

// Agregamos un componente obligatorio -> Esto fueza a que unity agregue 
// el componente si no existe en el objeto.
namespace Controller
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEffectController : MonoBehaviour, IListenable
    {
        #region IListenable_Properties

        public AudioClip AudioClip => _soundTrackClip;
        public void SetAudioClip(AudioClip clip) => _soundTrackClip = clip;
    
        [SerializeField] private AudioClip _soundTrackClip;
        public AudioSource AudioSource => _audioSource;
        private AudioSource _audioSource;
        #endregion

        #region IListenable_Methods
        public void InitAudioSource()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = AudioClip;
        }
    
        public void Play() => AudioSource.Play();
        public void Stop() => AudioSource.Stop();
        
        protected void Start()
        {
            InitAudioSource();
            Play();
        }
        #endregion
    
    }
}
