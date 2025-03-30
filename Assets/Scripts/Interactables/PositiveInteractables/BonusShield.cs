using UnityEngine;

namespace Interactables.PositiveInteractables
{
    [RequireComponent(typeof(CircleCollider2D))]

    public class BonusShield : Interactable<BonusShield>
    {
        [SerializeField] private float _shieldDuration = 4f;
        
        public float ShieldDuration => _shieldDuration;
    }
}