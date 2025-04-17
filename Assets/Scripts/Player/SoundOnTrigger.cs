using System.Linq;
using Controllers;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Audio;

namespace Player
{
    public class SoundOnTrigger : MonoBehaviour
    {
        [SerializeField] private SoundMapping _soundMapping;
        [SerializeField] private AudioSource _audioSource;
        
        [Header("Mixers")]
        [SerializeField] private AudioMixerGroup _masterMixer;
        [SerializeField] private AudioMixerGroup _sfxMixerGroup;
        [SerializeField] private AudioMixerGroup _musicMixerGroup;

        [Header("Snapshots")] 
        [SerializeField] private AudioMixerSnapshot _normal;
        [SerializeField] private AudioMixerSnapshot _inMenu;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent(out SoundIdentifier soundIdentifier))
            {
                var soundEntry = _soundMapping.sounds.FirstOrDefault
                    (s => s.identifier == soundIdentifier.identifier);
        
                if (soundEntry != null && soundEntry.clip != null)
                    _audioSource.PlayOneShot(soundEntry.clip);
            }
        }
        
        public void ToggleMusic(bool toggle)
        {
            if (toggle)
                _musicMixerGroup.audioMixer.SetFloat("MusicVolume", -80);
            else
                _musicMixerGroup.audioMixer.SetFloat("MusicVolume", 0);
        }

        public void FadeOut()
        {
            _inMenu.TransitionTo(0.5f);
        }

        public void FadeIn()
        {
            _normal.TransitionTo(0.5f);
        }
        
        public void SetMasterVolume(float volume)
        {
            _masterMixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
        }
        
        public void SetMusicVolume(float volume)
        {
            _musicMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        }

        public void SetSfxVolume(float volume)
        {
            _sfxMixerGroup.audioMixer.SetFloat("SFXVolume", Mathf.Lerp(-80, 0, volume));
        }
    }
}
