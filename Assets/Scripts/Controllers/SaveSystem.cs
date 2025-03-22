using Player;
using UnityEngine;

namespace Controllers
{
    public class SaveSystem : MonoBehaviour
    {
        // do nothing at this point
        
        public int GoldValue => _goldValue;
        
        private const string GoldKey = "Gold";
        private int _goldValue;
        
        private PlayerInteractable _playerInteractable;

        private void Start()
        {
            _playerInteractable = FindObjectOfType<PlayerInteractable>();
            
            LoadValue();
        }

        private void AddValue(int value)
        {
            _goldValue += value;
            SaveValue();
        }

        private void SpendValue(int value)
        {
            if (_goldValue >= value)
            {
                _goldValue -= value;
                SaveValue();
            }
        }

        private void SaveValue()
        {
            PlayerPrefs.SetInt(GoldKey, _goldValue);
            PlayerPrefs.Save();
        }

        private void LoadValue()
        {
            _goldValue = PlayerPrefs.GetInt(GoldKey);
        }
    }
}