using UnityEngine;

namespace TowerDefence.Currency
{
    public class CurrencySystem : MonoBehaviour
    {
        public bool Check(int _value)
        {
            int currentMoney = GetCurrency();

            bool ret = currentMoney >= _value;

            return ret;
        }

        public void Add(int _value)
        {
            int currentMoney = GetCurrency();
            int totalNumberMoney = currentMoney + _value;

            PlayerPrefs.SetInt("Money", totalNumberMoney);
        }

        public bool Take(int _value)
        {
            if (Check(_value))
            {
                int currentMoney = GetCurrency();
                int totalNumberMoney = currentMoney - _value;

                PlayerPrefs.SetInt("Money", totalNumberMoney);

                return true;
            }

            return false;
        }

        public int GetCurrency() =>
            PlayerPrefs.GetInt("Money");
    }
}