using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _skinsMenu;
    
        private static bool _isPaused;
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPaused)
                {
                    Resume();
                    _skinsMenu.SetActive(false);
                }
                else
                    Pause();
            }
        }
    
        public void Skins()
        {
            _pauseMenu.SetActive(false);
            _skinsMenu.SetActive(true);
        }
    
        public void Back()
        {
            _skinsMenu.SetActive(false);
            _pauseMenu.SetActive(true);
        }
    
        public void Resume()
        {
            _pauseMenu.SetActive(false);
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
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            _isPaused = true;
        }
    }
}
