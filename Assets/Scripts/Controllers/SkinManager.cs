using System.Collections.Generic;
using Player;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class SkinManager : MonoBehaviour
    {
        private const string ObtainedKey = "Obtained";
        private const string BuyKey = "Buy for: ";
        
        [SerializeField] private List<Skin> _skins;
        [SerializeField] private Text[] _text;

        private PlayerInteractable _playerInteractable;
        private PlayerMovement _playerMovement;
        private SpriteRenderer _spriteRenderer;
        
        private void Start()
        {
            _playerInteractable = PlayerInteractable.Instance;
            _spriteRenderer = _playerInteractable.GetComponent<SpriteRenderer>();
            _playerMovement = _playerInteractable.GetComponent<PlayerMovement>();
            
            LoadSkin();
        }

        public void Buy(int index)
        {
            if (index < 0 || index >= _skins.Count) return;

            Skin skin = _skins[index];

            if (skin.isPurchased)
            {
                ApplySkin(skin, index);
                return;
            }

            if (skin.price >= _playerInteractable.MaxGold)
            {
                Debug.Log("Not enough gold");
                return;
            }

            _playerInteractable.SpendGold(skin.price);
            _playerMovement.SetSpeedModifier(skin.speedModifier);
            skin.isPurchased = true;
            _spriteRenderer.sprite = skin.skinSprite;
            _text[index].text = ObtainedKey;
            
            PlayerPrefs.SetInt("SelectedSkinID", index);
            PlayerPrefs.Save();
        }

        private void LoadSkin()
        {
            for (int i = 0; i < _skins.Count; i++)
                _text[i].text = _skins[i].isPurchased ? ObtainedKey : BuyKey + _skins[i].price;

            int savedSkinID = PlayerPrefs.GetInt("SelectedSkinID", -1);

            if (savedSkinID >= 0 && savedSkinID < _skins.Count)
            {
                Skin selectedSkin = _skins[savedSkinID];
                _spriteRenderer.sprite = selectedSkin.skinSprite;
                _playerMovement.SetSpeedModifier(selectedSkin.speedModifier);
            }
        }

        private void ApplySkin(Skin skin, int index)
        {
            _spriteRenderer.sprite = skin.skinSprite;
            _playerMovement.SetSpeedModifier(skin.speedModifier);
            
            PlayerPrefs.SetInt("SelectedSkinID", index);
            PlayerPrefs.Save();
        }
    }
}
