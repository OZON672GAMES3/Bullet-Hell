using UI;
using Interactables.NegativeInteractables;
using Interactables.PositiveInteractables;
using ObjectPool;
using Spawners;
using UnityEngine;

namespace Player
{
    public class PlayerInteractable : MonoBehaviour
    {
        public static PlayerInteractable Instance { get; private set; }

        private static int _currentScore = 0;
        private static int _highScore = 0;
        private static int _maxGold = 0;
        
        private HealthManager _healthManager;
        private ObjectPool<BonusGold> _bonusGoldPool;
        private ObjectPool<DamageMine> _damageMinePool;
        private ObjectPool<BonusHealthKit> _bonusHealthKitPool;
        private ObjectPool<BonusShield> _bonusShieldPool;
        
        public int CurrentScore => _currentScore;

        public int HighScore
        {
            get => PlayerPrefs.GetInt("HighScore", _highScore);
            private set
            {
                _highScore = value;
                PlayerPrefs.SetInt("HighScore", _highScore);
                PlayerPrefs.Save();
            }
        }
        
        public int MaxGold
        {
            get => PlayerPrefs.GetInt("MaxGold", _maxGold);
            set
            {
                _maxGold = value;
                PlayerPrefs.SetInt("MaxGold", _maxGold);
                PlayerPrefs.Save();
            }
        }

        public void ResetScore()
        {
            _currentScore = 0;
        }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        void Start()
        {
            _healthManager = FindObjectOfType<HealthManager>();
            _bonusGoldPool = FindObjectOfType<GoldSpawner>()?.GetBonusGoldPool();
            _damageMinePool = FindObjectOfType<MinesSpawner>()?.GetDamageMinePool();
            _bonusHealthKitPool = FindObjectOfType<HealthSpawner>()?.GetBonusHealthKitPool();
            _bonusShieldPool = FindObjectOfType<ShieldSpawner>()?.GetBonusShieldPool();
            
            _highScore = PlayerPrefs.GetInt("HighScore", 0);
            InvokeRepeating(nameof(AddScore), 10, 10);
        }

        private void Update()
        {
            GetUpdatedScore();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent(out BonusGold bonusGold))
            {
                _currentScore += bonusGold.GoldValue;
                MaxGold += bonusGold.GoldValue;
                _bonusGoldPool.Release(bonusGold);
            }

            if (collider.gameObject.TryGetComponent(out BonusHealthKit bonusHealthKit))
            {
                _healthManager.TakeHealth();
                _bonusHealthKitPool.Release(bonusHealthKit);
            }

            if (collider.gameObject.TryGetComponent(out DamageMine damageMine))
            {
                if (!_healthManager.IsInvulnerable())
                    _healthManager.TakeDamage();
            
                if (damageMine)
                    _damageMinePool?.Release(damageMine);

                _currentScore += 10;
            }

            if (collider.gameObject.TryGetComponent(out BonusShield bonusShield))
            {
                _healthManager.Invulnerable();
                _bonusShieldPool.Release(bonusShield);
            }
        }

        private void GetUpdatedScore()
        {
            if (_currentScore > _highScore)
                HighScore = _currentScore;
        }

        private void AddScore()
        {
            _currentScore += 10;
        }
    }
}
