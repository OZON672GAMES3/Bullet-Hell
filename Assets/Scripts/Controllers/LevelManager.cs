using System.Collections;
using Player;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject _endLevelUI;
        [SerializeField] private GameObject _looseScreen;

        private HealthManager _healthManager;
        private PlayerInteractable _playerInteractable;
        
        private void Start()
        {
            _playerInteractable = PlayerInteractable.Instance;
            _healthManager = FindObjectOfType<HealthManager>();
            Time.timeScale = 1;
        }

        private void Update()
        {
            if (_healthManager.CurrentLives <= 0)
            {
                Time.timeScale = 0;
                _looseScreen.SetActive(true);
            }
        }

        public void RestartLevel()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
            _playerInteractable.ResetScore();
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }

        public void NextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
            Time.timeScale = 1;
        }

        private IEnumerator EndGame()
        {
            WaitForSeconds wait = new WaitForSeconds(60f);
            yield return wait;
        
            Time.timeScale = 0f;
            _endLevelUI.SetActive(true);
        }
    }
}