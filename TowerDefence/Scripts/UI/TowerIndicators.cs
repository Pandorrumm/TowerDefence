using TMPro;
using UnityEngine;

namespace TowerDefence.UI
{
    public class TowerIndicators : MonoBehaviour
    {
        [SerializeField] private TMP_Text speedIndicatorText;
        [SerializeField] private TMP_Text damageIndicatorText;
        [SerializeField] private TMP_Text damageDistanceIndicatorText;

        public void UpdateText(float _speedValue, float _damageValue, float _damageDistanceValue)
        {
            speedIndicatorText.text = _speedValue.ToString();
            damageIndicatorText.text = _damageValue.ToString();
            damageDistanceIndicatorText.text = _damageDistanceValue.ToString();
        }
    }
}
