using System.Collections;
using Interactables.NegativeInteractables;
using Interactables.PositiveInteractables;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private Image[] _lifeImage;
        [SerializeField] private DamageMine _damageMine;
        [SerializeField] private BonusHealthKit _bonusHealthKit;
        [SerializeField] private BonusShield _bonusShield;
        [SerializeField] private SlowMine _slowMine;

        private int _maxLives = 3;
        private int _currentLives;

        private float _invulnerableDuration;
        
        private bool _isInvulnerable = true;

        private SpriteRenderer _spriteRenderer;

        public int CurrentLives => _currentLives;
    
        void Start()
        {
            _spriteRenderer = PlayerInteractable.Instance.GetComponent<SpriteRenderer>();
            _currentLives = _maxLives;
            _invulnerableDuration = _bonusShield.ShieldDuration;
            UpdateUI();
        }
    
        public void TakeDamage()
        {
            if (_currentLives > 0)
            {
                _currentLives -= _damageMine.DamageValue;
                UpdateUI();
            }
        }
    
        public void TakeHealth()
        {
            if (_currentLives < _maxLives)
            {
                _currentLives += _bonusHealthKit.BonusHealth;
                UpdateUI();
            }
        }
    
        public void Invulnerable()
        {
            if (!_isInvulnerable)
            {
                _isInvulnerable = true;
                StartCoroutine(InvulnerableCountdown(_invulnerableDuration));
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
    
        private IEnumerator InvulnerableCountdown(float duration)
        {
            _spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(duration);
            
            _spriteRenderer.color = Color.white;
            _isInvulnerable = false;
        }
    }
}
