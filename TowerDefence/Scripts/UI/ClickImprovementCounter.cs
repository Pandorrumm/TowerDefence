using TowerDefence.StaticData;
using UnityEngine;

namespace TowerDefence.UI
{
    public class ClickImprovementCounter : MonoBehaviour
    {
        [SerializeField] private ImprovementData improvement;
        [SerializeField] private BlockImprovementButton blockImprovementButton;

        private int clickCounter;

        public void ClickCounter()
        {
            clickCounter++;
            CheckBlockButton(clickCounter);
        }

        private void CheckBlockButton(int _value)
        {
            if (_value >= improvement.MagnificationsNumber)
            {
                blockImprovementButton.BlockButton();
            }
        }
    }
}
