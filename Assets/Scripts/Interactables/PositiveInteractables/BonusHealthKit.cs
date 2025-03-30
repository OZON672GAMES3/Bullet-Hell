using UnityEngine;

namespace Interactables.PositiveInteractables
{
    [RequireComponent(typeof(CircleCollider2D))]

    public class BonusHealthKit : Interactable<BonusHealthKit>
    {
        [SerializeField] private int _bonusHealth = 1;
        
        public int BonusHealth => _bonusHealth;
    }
}