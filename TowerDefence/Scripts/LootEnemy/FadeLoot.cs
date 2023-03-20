using UnityEngine;
using DG.Tweening;

namespace TowerDefence.LootEnemy
{
    public class FadeLoot : MonoBehaviour
    {
        [SerializeField] private float duration;
        [SerializeField] private float delay;

        private CanvasGroup canvasGroup;

        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();

            Fade();
        }

        private void Fade()
        {
            canvasGroup.DOFade(0, duration)
                .SetDelay(delay)
                .OnComplete(() => gameObject.SetActive(false));
        }
    }
}
