using UnityEngine;

namespace TowerDefence.LootEnemy
{
    public class Loot : MonoBehaviour
    {
        [SerializeField] private int lootNumberMoney;

        public int GetLootNumberMoney() =>
            lootNumberMoney;
    }
}
