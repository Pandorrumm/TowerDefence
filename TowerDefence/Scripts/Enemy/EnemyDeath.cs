using UnityEngine;
using DG.Tweening;
using System.Collections;
using TowerDefence.Tower;
using TowerDefence.WaveOfEnemies;
using TowerDefence.Currency;
using TowerDefence.LootEnemy;

namespace TowerDefence.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth health;
        [SerializeField] private EnemyAttack enemyAttack;
        [SerializeField] private GameObject enemyView;

        [Space]
        [SerializeField] private GameObject deathFx;
        [SerializeField] private GameObject lootPrefab;

        private TowerAttack tower;
        private WaveSpawner waveSpawner;
        private CurrencyAnimation currencyAnimation;
        private BoxCollider2D enemyCollider;
        private GameObject loot;
        private float delayDead;
        private int lootMoney;

        public void Construct(TowerAttack _tower, WaveSpawner _waveSpawner, CurrencyAnimation _currencyAnimation)
        {
            tower = _tower;
            waveSpawner = _waveSpawner;
            currencyAnimation = _currencyAnimation;
        }

        private void Start()
        {
            health.HealthChanged += HealthChanged;

            enemyCollider = GetComponent<BoxCollider2D>();
        }

        private void OnDestroy() =>
             health.HealthChanged -= HealthChanged;


        private void HealthChanged()
        {
            if (health.Current <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            health.HealthChanged -= HealthChanged;

            tower.RemoveDeadEnemy(this.gameObject);
            waveSpawner.RemoveEnemy();

            enemyAttack.attackSequence.Kill();

            DisableComponents();

            enemyView.SetActive(false);

            CreateLoot();

            currencyAnimation.AnimateCurrency(lootMoney);

            CreateDeadFx();

            StartCoroutine(DestroyTimer());
        }

        private void DisableComponents()
        {
            health.enabled = false;
            enemyAttack.enabled = false;
            enemyCollider.enabled = false;
        }

        private void CreateLoot()
        {
            loot = Instantiate(lootPrefab, transform.position, Quaternion.identity);

            if (loot.TryGetComponent<Loot>(out var Loot))
            {
                lootMoney = Loot.GetLootNumberMoney();
            }

            if (loot.TryGetComponent<LootMovement>(out var LootMovement))
            {
                delayDead = LootMovement.GetDurationLootMovement();
            }
        }

        private void CreateDeadFx() => 
            Instantiate(deathFx, transform.position, Quaternion.identity);

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(delayDead);
            Destroy(gameObject);
        }
    }
}
