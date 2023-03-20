using UnityEngine;

namespace TowerDefence.Factory
{ 
    public abstract class AbstractFactory
    {
        public abstract GameObject CreateObject(GameObject _gameObject);
    }
}
