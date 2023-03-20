using UnityEngine;
using System;

namespace TowerDefence.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float distanceToTarget = 0.1f;
        [SerializeField] private float minSpeed = 0.1f;
        [SerializeField] private float maxSpeed = 1f;

        private float speed;
        private Transform target;
        private bool isMove;
        private Vector3 direction;

        public event Action OnCameToTarget;

        public void Construct(Transform _target) => 
            target = _target;

        private void Start() => 
            StartMoving();

        private void Update() => 
            Move();

        private void Move()
        {
            if (isMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

                direction = target.transform.position - transform.position;

                if (direction.sqrMagnitude < distanceToTarget)
                {
                    isMove = false;

                    OnCameToTarget?.Invoke();
                }               
            }
        }

        public void StartMoving()
        {
            if (target != null)
            {
                speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
                isMove = true;
            }
        }
    }
}
