using TMPro;
using UnityEngine;

namespace TowerDefence.UI
{
    public class MoneyCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text currencyText;

        public TMP_Text SetText() =>
            currencyText;
    }
}
