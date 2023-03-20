using System.Collections.Generic;
using TowerDefence.Tower;
using TowerDefence.UI;
using TowerDefence.WaveOfEnemies;
using UnityEngine;
using TowerDefence.Currency;
using TowerDefence.Bullet;

namespace TowerDefence.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GameObject canvasPrefab;

        [Header("Tower")]
        [SerializeField] private GameObject towerPrefab;
        [SerializeField] private Transform towerSpawnPoint;

        [Header("Wave")]
        [SerializeField] private WaveSpawner waveSpawnerPrefab;
        [SerializeField] private List<Transform> enemySpawnPoints = new List<Transform>();

        [Header("Currency System")]
        [SerializeField] private GameObject currencySystemPrefab;

        private GameObject gameCanvas;
        private WaveSpawner waveSpawner;
        private GameObject tower;
        private GameObject currencySystem;

        private void Awake()
        {
            CreateTower();
            CreateCurrencySystem();
            CreateHud();         
            CreateWaveSpawner();
        }

        private void CreateHud()
        {
            gameCanvas = Instantiate(canvasPrefab);

            gameCanvas.GetComponentInChildren<ActorUI>().Construct(tower.GetComponent<TowerHealth>());
            gameCanvas.GetComponentInChildren<Improvements>().Construct(currencySystem.GetComponent<CurrencySystem>(),
                                                                        currencySystem.GetComponent<CurrencyAnimation>(),
                                                                        tower.GetComponentInChildren<BulletMovement>(),
                                                                        tower.GetComponentInChildren<BulletDamage>(),
                                                                        tower.GetComponentInChildren<AttackZone>());
            
            if (currencySystem.TryGetComponent<CurrencyAnimation>(out var CurrencyAnimation))
            {
                CurrencyAnimation.Construct(gameCanvas.GetComponentInChildren<MoneyCounter>().SetText());
            }
        }

        private void CreateTower() => 
            tower = Instantiate(towerPrefab, towerSpawnPoint.position, Quaternion.identity);

        private void CreateCurrencySystem() => 
            currencySystem = Instantiate(currencySystemPrefab);

        private void CreateWaveSpawner()
        {
            waveSpawner = Instantiate(waveSpawnerPrefab);
            waveSpawner.Construct(tower, enemySpawnPoints, currencySystem.GetComponent<CurrencyAnimation>(), gameCanvas.GetComponentInChildren<WaveCounter>());         
        }
    }
}
