using UnityEngine;
using DG.Tweening;

namespace TowerDefence.LootEnemy
{
    public class LootMovement : MonoBehaviour
    {
        [SerializeField] private GameObject loot;
        [SerializeField] private Transform target;
        [SerializeField] private float durationMovement = 0.5f;

        private void Start() => 
            loot.transform.DOMove(target.position, durationMovement);

        public float GetDurationLootMovement() =>
            durationMovement;
    }
}
