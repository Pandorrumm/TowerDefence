using DG.Tweening;
using UnityEngine;

namespace TowerDefence.UI
{
    public class ShakeButton : MonoBehaviour
    {
        [SerializeField] private float shakeDuration = 0.5f;

        private Transform transformButton;

        private void Start() =>
            transformButton = GetComponent<Transform>();

        public void Shake() =>
            transformButton.DOShakeScale(shakeDuration, 0.5f, 2, 0, false);
    }
}
