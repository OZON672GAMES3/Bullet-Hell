using Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenuPanel;
        [SerializeField] private GameObject _chooseLevelPanel;
        [SerializeField] private GameObject _skinPanel;
        [SerializeField] private Text _goldValue;
    
        private void Awake()
        {
            _mainMenuPanel.SetActive(true);
            _chooseLevelPanel.SetActive(false);
            _skinPanel.SetActive(false);
        }
        
        public void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(levelIndex);
        }
    
        public void Play()
        {
            _mainMenuPanel.SetActive(false);
            _chooseLevelPanel.SetActive(false);
            _chooseLevelPanel.SetActive(true);
        }
    
        public void Back()
        {
            _chooseLevelPanel.SetActive(false);
            _skinPanel.SetActive(false);
            _mainMenuPanel.SetActive(true);
        }
    
        public void Skin()
        {
            _mainMenuPanel.SetActive(false);
            _chooseLevelPanel.SetActive(false);
            _skinPanel.SetActive(true);
        }
    }
}
