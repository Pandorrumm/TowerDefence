using TowerDefence.Enemy;
using UnityEngine;
using DG.Tweening;

namespace TowerDefence.Tower
{
    public class AttackZone : MonoBehaviour
    {
        [SerializeField] private TowerAttack towerAttack;

        [Space]
        [SerializeField] private float durationOfGrowth = 0.5f;

        private Transform attackZoneTransform;
        private Vector3 currentScale;
        private Vector3 previousScale;

        private void Start()
        {            
            attackZoneTransform = GetComponent<Transform>();

            currentScale = attackZoneTransform.localScale;
            previousScale = currentScale;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<EnemyHealth>())
            {
                towerAttack.Attack(other.gameObject);
            }
        }

        public void IncreaseDamageDistance(float _value)
        {
            currentScale = new Vector3(previousScale.x + _value, previousScale.y + _value, previousScale.y + _value);
            attackZoneTransform.DOScale(currentScale, durationOfGrowth);

            previousScale = currentScale;
        }

        public float SetDamageDistance() =>
            currentScale.x;
    }
}
