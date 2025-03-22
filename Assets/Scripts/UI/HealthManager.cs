using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private Image[] _lifeImage;
        
        private int _maxLives = 3;
        private int _currentLives;
        private bool _isInvulnerable;
        private SpriteRenderer _spriteRenderer;
        
        public int CurrentLives => _currentLives;
    
        void Start()
        {
            _spriteRenderer = FindObjectOfType<PlayerInteractable>().GetComponent<SpriteRenderer>();
            _currentLives = _maxLives;
            UpdateUI();
        }
    
        public void TakeDamage()
        {
            if (_currentLives > 0)
            {
                _currentLives--;
                UpdateUI();
            }
        }
    
        public void TakeHealth()
        {
            if (_currentLives < _maxLives)
            {
                _currentLives++;
                UpdateUI();
            }
        }
    
        public void Invulnerable()
        {
            if (!_isInvulnerable)
            {
                _isInvulnerable = true;
                StartCoroutine(InvulnerableCountdown());
            }
        }
    
        public bool IsInvulnerable()
        {
            return _isInvulnerable;
        }
    
        private void UpdateUI()
        {
            for (int i = 0; i < _lifeImage.Length; i++)
                _lifeImage[i].enabled = i < _currentLives;
        }
    
        private IEnumerator InvulnerableCountdown()
        {
            _spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(4f);
            
            _spriteRenderer.color = Color.white;
            _isInvulnerable = false;
        }
    }
}
