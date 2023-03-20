using System.Collections;
using TowerDefence.Tower;
using UnityEngine;
using DG.Tweening;

namespace TowerDefence.Bullet
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float shootCooldown = 0.7f;
        [SerializeField] private GameObject trail;

        [Space]
        [SerializeField] private TowerAttack towerAttack;
      
        private Vector3 startPosition;
        private SpriteRenderer spriteRenderer;
        private bool isMove;
        private Transform target;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            startPosition = transform.position;
            spriteRenderer.enabled = false;
        }

        private void Update() =>
            Move();

        private void Move()
        {
            if (isMove)
            {
                if (target != null)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }           
            }
        }

        public void StopMoving()
        {
            isMove = false;

            trail.SetActive(false);

            spriteRenderer.enabled = false;

            transform.position = startPosition;
        }

        public void StartMoving()
        {
            DOTween.Sequence()
                     .AppendInterval(shootCooldown)
                     .AppendCallback(BulletMoving);
        }

        private void BulletMoving()
        {
            if (target != null)
            {
                spriteRenderer.enabled = true;
                isMove = true;

                trail.SetActive(true);
            }
        }

        public void IncreaseSpeed(float _value) => 
            speed = speed + _value;

        public void RestartBulletMoving() => 
            StartMoving();

        public void GetTarget(Transform _target) => 
            target = _target;

        public float SetSpeed() =>
            speed;

        public void DeleteTarget() => 
            target = null;
    }
}
