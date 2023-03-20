using DG.Tweening;
using TowerDefence.Logic;
using UnityEngine;

namespace TowerDefence.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private EnemyMovement enemyMovement;
        [SerializeField] private float attackCooldown = 1f;
        [SerializeField] private float damage = 1f;

        public Sequence attackSequence;

        private GameObject tower;

        public void Construct(GameObject _tower) => 
            tower = _tower;

        private void OnEnable() => 
            enemyMovement.OnCameToTarget += StartAttack;

        private void OnDisable() => 
            enemyMovement.OnCameToTarget -= StartAttack;

        private void StartAttack() => 
            Attack();

        private void Attack()
        {
            tower.transform.GetComponent<IHealth>().TakeDamage(damage);

            attackSequence = DOTween.Sequence()
                               .AppendInterval(attackCooldown)
                               .AppendCallback(StartAttack);
        }
    }
}