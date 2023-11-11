using UnityEngine;

namespace Core.Games.GameName
{
    public class AudioManager : MonoBehaviour
    {
        [Header("     Audio Source     ")]
        [SerializeField] AudioSource SFXSource;

        [Header("     Audio Clip     ")]
        public AudioClip hitSound;
        public AudioClip explosionSound;

        public void PlaySFX(AudioClip clip)
        {
            SFXSource.PlayOneShot(clip);
        }
    }
}
