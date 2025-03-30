using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenuPanel;
        [SerializeField] private GameObject _settingsPanel;
        private Text _goldValue;
    
        private PlayerInteractable _playerInteractable;
        
        private void Awake()
        {
            _mainMenuPanel.SetActive(true);
            _settingsPanel.SetActive(false);
        }

        private void Start()
        {
            _playerInteractable = PlayerInteractable.Instance;
        }
    
        public void Play()
        {
                SceneManager.LoadScene(1);
        }

        public void Settings()
        {
            _mainMenuPanel.SetActive(false);
            _settingsPanel.SetActive(true);
        }

        public void Back()
        {
            _mainMenuPanel.SetActive(true);
            _settingsPanel.SetActive(false);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
