using UnityEngine;
using DG.Tweening;

namespace TowerDefence.UI
{
    public class NoMoney : MonoBehaviour
    {
        [SerializeField] private GameObject targetMovement = null;
        [SerializeField] private float durationMovement = 1f;

        [Space]
        [SerializeField] private GameObject noMoneyPanel = null;

        private Vector3 startPosition;

        private void Start()
        {
            startPosition = noMoneyPanel.transform.position;
        }

        public void StatusNoMoneyPanel(bool _status)
        {
            noMoneyPanel.SetActive(_status);

            if (_status)
            {             
                noMoneyPanel.transform.DOMove(targetMovement.transform.position, durationMovement).OnComplete(() => ReturnPosition());
            }             
        }

        private void ReturnPosition()
        {
            StatusNoMoneyPanel(false);
            noMoneyPanel.transform.DOMove(startPosition, 0);
        }
    }
}
