using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SoundMapping", menuName = "SoundSystem/SoundMapping")]
    public class SoundMapping : ScriptableObject
    {
        public List<SoundEntry> sounds;
    }

    [System.Serializable]
    public class SoundEntry
    {
        public string identifier;
        public AudioClip clip;
    }
}