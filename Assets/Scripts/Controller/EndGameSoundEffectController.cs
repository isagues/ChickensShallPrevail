using Manager;
using UnityEngine;

// Agregamos un componente obligatorio -> Esto fueza a que unity agregue 
// el componente si no existe en el objeto.
namespace Controller
{
    [RequireComponent(typeof(AudioSource))]
    public class EndGameSoundEffectController : SoundEffectController
    {

        [SerializeField] private AudioClip _victoryClip;
        [SerializeField] private AudioClip _defeatClip;

        private new void Start()
        {
            SetAudioClip(GlobalData.instance.IsVictory ? _victoryClip : _defeatClip);
            base.Start();
        }
    }
}
