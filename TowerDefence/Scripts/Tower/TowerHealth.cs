using TowerDefence.Logic;
using System;
using UnityEngine;

namespace TowerDefence.Tower
{
    public class TowerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float currentHP;
        [SerializeField] private float maxHP;

        [Space]
        [SerializeField] private ParticleSystem damageParticle;

        public event Action HealthChanged;

        private void Start() => 
            damageParticle.Stop();

        public float Current
        {
            get => currentHP;
            set
            {
                if (currentHP != value)
                {
                    currentHP = value;

                    HealthChanged?.Invoke();
                }
            }
        }

        public float Max
        {
            get => maxHP;
            set => maxHP = value;
        }

        public void TakeDamage(float damage)
        {
            if (Current <= 0)
            {
                return;
            }
            else
            {
                damageParticle.Play();
            }
            
            Current -= damage;

            HealthChanged?.Invoke();
        }
    }
}