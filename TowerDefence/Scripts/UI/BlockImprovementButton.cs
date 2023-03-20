using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.UI
{
    public class BlockImprovementButton : MonoBehaviour
    {
        [SerializeField] private Sprite blockSprite;
        [SerializeField] private Image buttonImage;

        private Button improvementButton;

        private void Start() =>
            improvementButton = GetComponent<Button>();

        public void BlockButton()
        {
            improvementButton.enabled = false;
            buttonImage.sprite = blockSprite;
        }
    }
}
