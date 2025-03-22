using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "NewSkin", menuName = "Skins/Skin")]
    public class Skin : ScriptableObject
    {
        public int skinID;
        public Sprite skinSprite;
        public int price;
        public bool isPurchased;
        public float speedModifier;
    }
}
