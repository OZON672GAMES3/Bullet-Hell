using System.Linq;
using Controllers;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
    public class SoundOnTrigger : MonoBehaviour
    {
        public AudioSource _audioSource;
        public SoundMapping _soundMapping;

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
    }
}