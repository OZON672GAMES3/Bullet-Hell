using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Text _goldValue;
        [SerializeField] private Text _scoreValue;
        [SerializeField] private Text _highScoreValue;
    
        private PlayerInteractable _playerInteractable;
    
        private void Start()
        {
            _playerInteractable = PlayerInteractable.Instance;
            Application.runInBackground = true;
        }

        private void Update()
        {
            Gold();
            Score();
            HighScore();
        }

        private void Score()
        {
            _scoreValue.text = "Score: " + _playerInteractable.CurrentScore;
        }

        private void HighScore()
        {
            _highScoreValue.text = "High score: " + _playerInteractable.HighScore;
        }

        private void Gold()
        {
            _goldValue.text = "Gold: " + _playerInteractable.MaxGold;
        }
    }
}
