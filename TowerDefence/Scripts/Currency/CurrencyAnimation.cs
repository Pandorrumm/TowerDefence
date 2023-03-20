using DG.Tweening;
using TMPro;
using UnityEngine;

namespace TowerDefence.Currency
{
    public class CurrencyAnimation : MonoBehaviour
    {
        [SerializeField] private float increaseDuration = 0.5f;
        [SerializeField] private float decreaseDuration = 0.5f;

        private TMP_Text currencyText;
        private CurrencySystem currencySystem;

        private int _m = 0;
        public int Money
        {
            get { return _m; }
            set
            {
                _m = value;
                currencyText.text = Money.ToString();
            }
        }

        public void Construct(TMP_Text _currencyText) => 
            currencyText = _currencyText;

        private void Start()
        {
            currencySystem = GetComponent<CurrencySystem>();
            Money = currencySystem.GetCurrency();
        }

        public void AnimateCurrency(int _amount)
        {
            Money = currencySystem.GetCurrency();

            currencySystem.Add(_amount);

            DOTween.To(() => Money, x => Money = x, Money + _amount, increaseDuration);
        }

        public void DecreaseCurrency(int _amount)
        {
            Money = currencySystem.GetCurrency();

            currencySystem.Take(_amount);

            DOTween.To(() => Money, x => Money = x, Money - _amount, decreaseDuration);
        }
    }
}
