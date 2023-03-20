using UnityEngine;

namespace TowerDefence.Factory
{
    public class EnemyFactory : AbstractFactory
    {
        private Transform parent;

        public EnemyFactory(Transform _parent) => 
            parent = _parent;

        public override GameObject CreateObject(GameObject _enemy)
        {
            GameObject enemy = GameObject.Instantiate(_enemy, parent);
            return enemy;
        }
    }
}
