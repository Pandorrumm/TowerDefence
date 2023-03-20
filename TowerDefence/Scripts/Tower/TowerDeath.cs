using UnityEngine;

namespace TowerDefence.Tower
{
     [RequireComponent(typeof(TowerHealth))]
    public class TowerDeath : MonoBehaviour
    {
        [SerializeField] private TowerHealth health;
        [SerializeField] private GameObject deathFx;

        private bool _isDead;

        private void Start() => 
            health.HealthChanged += HealthChanged;

        private void OnDestroy() => 
            health.HealthChanged -= HealthChanged;

        private void HealthChanged()
        {
            if (!_isDead && health.Current <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _isDead = true;

            CreateDeadFx();
            gameObject.SetActive(false);            
        }

        private void CreateDeadFx() =>
            Instantiate(deathFx, transform.position, Quaternion.identity);
    }
}