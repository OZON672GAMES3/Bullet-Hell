using UnityEngine;

namespace Interactables.NegativeInteractables
{
    [RequireComponent(typeof(CircleCollider2D))]

    public class SlowMine : Interactable<SlowMine>
    {
        [SerializeField] private float _slowDuration = 4f;
        [SerializeField] private float _slowMultiplier = 0.5f;
        
        public float SlowDuration => _slowDuration;
        public float SlowMultiplier => _slowMultiplier;
    }
}