using System;
using TMPro;
using TowerDefence.Bullet;
using TowerDefence.Currency;
using TowerDefence.StaticData;
using TowerDefence.Tower;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.UI
{
    public class Improvements : MonoBehaviour
    {
        [Header("Improvement Data")]
        [SerializeField] private ImprovementData speed;
        [SerializeField] private ImprovementData damage;
        [SerializeField] private ImprovementData damageDistance;

        [Header("Buttons")]
        [SerializeField] private Button addSpeedButton;
        [SerializeField] private Button addDamageButton;
        [SerializeField] private Button addDamageDistanceButton;

        [Header("TMP_Text")]
        [SerializeField] private TMP_Text priceSpeedText;
        [SerializeField] private TMP_Text priceDamageText;
        [SerializeField] private TMP_Text priceDamageDistanceText;

        [Header("ClickImprovementCounter")]
        [SerializeField] private ClickImprovementCounter clickSpeed;
        [SerializeField] private ClickImprovementCounter clickDamage;
        [SerializeField] private ClickImprovementCounter clickDamageDistance;

        [Header("ShakeButton")]
        [SerializeField] private ShakeButton shakeSpeed;
        [SerializeField] private ShakeButton shakeDamage;
        [SerializeField] private ShakeButton shakeDamageDistance;

        [Space]
        [SerializeField] private TowerIndicators towerIndicators;
        [SerializeField] private NoMoney noMoneyPanel;

        private CurrencySystem currencySystem;
        private CurrencyAnimation currencyAnimation;
        private BulletMovement bulletMovement;
        private BulletDamage bulletDamage;
        private AttackZone attackZone;

        public void Construct(CurrencySystem _currencySystem, CurrencyAnimation _currencyAnimation, BulletMovement _bulletMovement, BulletDamage _bulletDamage, AttackZone _attackZone)
        {
            currencySystem = _currencySystem;
            currencyAnimation = _currencyAnimation;
            bulletMovement = _bulletMovement;
            bulletDamage = _bulletDamage;
            attackZone = _attackZone;
        }

        private void Start()
        {
            addSpeedButton.onClick.AddListener(() => AddImprovement(speed, clickSpeed, shakeSpeed, () => bulletMovement.IncreaseSpeed(speed.IncreaseValueStep)));
            addDamageButton.onClick.AddListener(() => AddImprovement(damage, clickDamage, shakeDamage, () => bulletDamage.IncreaseDamage(damage.IncreaseValueStep)));
            addDamageDistanceButton.onClick.AddListener(() => AddImprovement(damageDistance, clickDamageDistance, shakeDamageDistance, () => attackZone.IncreaseDamageDistance(damageDistance.IncreaseValueStep)));

            priceSpeedText.text = speed.PriceImprovement.ToString();
            priceDamageText.text = damage.PriceImprovement.ToString();
            priceDamageDistanceText.text = damageDistance.PriceImprovement.ToString();

            towerIndicators.UpdateText(bulletMovement.SetSpeed(), bulletDamage.SetDamage(), attackZone.SetDamageDistance());
        }

        private void AddImprovement(ImprovementData _improvement, ClickImprovementCounter _clickImprovementCounter, ShakeButton _shakeButton, Action _action)
        {
            if (currencySystem.Check(_improvement.PriceImprovement))
            {
                _action?.Invoke();

                _clickImprovementCounter.ClickCounter();

                currencyAnimation.DecreaseCurrency(_improvement.PriceImprovement);

                towerIndicators.UpdateText(bulletMovement.SetSpeed(), bulletDamage.SetDamage(), attackZone.SetDamageDistance());

                _shakeButton.Shake();
            }
            else
            {
                noMoneyPanel.StatusNoMoneyPanel(true);
            }
        }
    }
}
