using System.Collections.Generic;
using TowerDefence.Bullet;
using UnityEngine;

namespace TowerDefence.Tower
{
    public class TowerAttack : MonoBehaviour
    {
        [SerializeField] private BulletMovement bulletMovement;

        private List<GameObject> enemies = new List<GameObject>();

        public void Attack(GameObject _target)
        {
            enemies.Add(_target);

            if (enemies.Count == 1)
            {
                ActivateBullet();
            }           
        }

        public void RemoveDeadEnemy(GameObject _deadEnemy)
        {
            enemies.Remove(_deadEnemy);
            bulletMovement.DeleteTarget();
            ActivateBullet();
        }

        private void ActivateBullet()
        {
            if (enemies.Count > 0)
            {
                bulletMovement.GetTarget(enemies[0].transform);
                bulletMovement.StartMoving();
            }       
        }
    }
}
