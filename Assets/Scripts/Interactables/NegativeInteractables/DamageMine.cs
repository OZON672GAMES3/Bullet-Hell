using UnityEngine;

namespace Interactables.NegativeInteractables
{
    [RequireComponent(typeof(CircleCollider2D))]

    public class DamageMine : Interactable<DamageMine>
    {
        [SerializeField] private int _damageValue = 1;
        
        public int DamageValue => _damageValue;
    }
}