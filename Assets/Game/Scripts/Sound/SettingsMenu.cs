using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Core.Games.GameName
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] public AudioMixer audioMixer;
        [SerializeField] public Slider musicSlider;

        private void Start()
        {
            SetMusicVolume();
        }
        public void SetMusicVolume()
        {
            float volume = musicSlider.value;
            audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        }

        public void GameQuit()
        {
            Application.Quit();
        }

    }
}
