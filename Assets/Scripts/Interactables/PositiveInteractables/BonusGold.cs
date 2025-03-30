using UnityEngine;

namespace Interactables.PositiveInteractables
{
    [RequireComponent(typeof(CircleCollider2D))]

    public class BonusGold : Interactable<BonusGold>
    {
        [SerializeField] private int _goldValue = 10;

        public int GoldValue => _goldValue;
    }
}
