using System;
using System.Collections.Generic;
using TowerDefence.Currency;
using TowerDefence.Enemy;
using TowerDefence.Factory;
using TowerDefence.StaticData;
using TowerDefence.Tower;
using TowerDefence.UI;
using UnityEngine;

namespace TowerDefence.WaveOfEnemies
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private List<WaveTeamData> waveTeamsDatas = new List<WaveTeamData>();

        private int numberEnemies;
        private int indexWave = 0;

        private GameObject target;
        private CurrencyAnimation currencyAnimation;
        private List<Transform> spawnPoints = new List<Transform>();
        private AbstractFactory abstractFactory;
        private WaveCounter waveCounter;

        public event Action<GameObject> OnCreateEnemy;

        public void Construct(GameObject _target, List<Transform> _spawnPoints, CurrencyAnimation _currencyAnimation, WaveCounter _waveCounter)
        {
            target = _target;

            for (int i = 0; i < _spawnPoints.Count; i++)
            {
                spawnPoints.Add(_spawnPoints[i]);
            }

            currencyAnimation = _currencyAnimation;
            waveCounter = _waveCounter;
        }

        private void Start()
        {
            abstractFactory = new EnemyFactory(this.transform);

            StartCreationWave();
        }

        private void StartCreationWave()
        {
            if (indexWave >= waveTeamsDatas.Count)
            {
                return;
            }

            waveCounter.UpdateWaveCounterText(indexWave + 1);

            CreateEnemies();
        }

        private void CreateEnemies()
        {
            for (int i = 0; i < waveTeamsDatas[indexWave].enemies.Count; i++)
            {
                GameObject enemy = abstractFactory.CreateObject(waveTeamsDatas[indexWave].enemies[i]);

                InitializingEnemy(enemy);

                numberEnemies++;

                enemy.transform.position = GetRandomSpawnPoints(spawnPoints).position;
            }      
        }

        private void InitializingEnemy(GameObject _enemy)
        {
            if (_enemy.TryGetComponent<EnemyMovement>(out var EnemyMovement))
            {
                EnemyMovement.Construct(target.transform);
            }

            if (_enemy.TryGetComponent<EnemyAttack>(out var EnemyAttack))
            {
                EnemyAttack.Construct(target);
            }

            if (_enemy.TryGetComponent<EnemyDeath>(out var EnemyDeath))
            {
                EnemyDeath.Construct(target.GetComponent<TowerAttack>(), this, currencyAnimation);
            }
        }

        private Transform GetRandomSpawnPoints(List<Transform> _spawnPoints)
        {
            int max = _spawnPoints.Count;
            int min = 0;
            int index = UnityEngine.Random.Range(min, max);

            return _spawnPoints[index];
        }

        public void RemoveEnemy()
        {
            numberEnemies--;

            if (numberEnemies <= 0)
            {
                indexWave++;

                StartCreationWave();
            }
        }
    }
}
