using TowerDefence.Logic;
using System;
using UnityEngine;

namespace TowerDefence.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float current;
        [SerializeField] private float max;

        [Space]
        [SerializeField] private ParticleSystem damageParticle;

        public event Action HealthChanged;

        private void Start()
        {
            damageParticle.Stop();
        }

        public float Current
        {
            get => current;
            set => current = value;
        }

        public float Max
        {
            get => max;
            set => max = value;
        }

        public void TakeDamage(float damage)
        {
            Current -= damage;

            if (Current > 0)
            {
                damageParticle.Play();
            }           

            HealthChanged?.Invoke();
        }
    }
}