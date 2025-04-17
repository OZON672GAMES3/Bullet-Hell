using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _skinsMenu;
        [SerializeField] private GameObject _settingsMenu;
        
        [Inject] private SoundOnTrigger _soundOnTrigger;

        private static bool _isPaused;
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPaused)
                    Resume();
                else
                    Pause();
            }
        }
    
        public void Skins()
        {
            _pauseMenu.SetActive(false);
            _skinsMenu.SetActive(true);
        }

        public void Settings()
        {
            _pauseMenu.SetActive(false);
            _skinsMenu.SetActive(false);
            _settingsMenu.SetActive(true);
        }
    
        public void Back()
        {
            _skinsMenu.SetActive(false);
            _settingsMenu.SetActive(false);
            _pauseMenu.SetActive(true);
        }
    
        public void Resume()
        {
            _soundOnTrigger.FadeIn();
            _pauseMenu.SetActive(false);
            _skinsMenu.SetActive(false);
            _settingsMenu.SetActive(false);
            Time.timeScale = 1f;
            _isPaused = false;
        }
    
        public void LoadMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    
        public void Quit()
        {
            Debug.Log("Quitting game");
            Application.Quit();
        }
        
        void Pause()
        {
            _soundOnTrigger.FadeOut();
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            _isPaused = true;
        }
    }
}
