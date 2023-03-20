﻿using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.UI
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Image ImageCurrent;

        public void SetValue(float current, float max) => 
            ImageCurrent.fillAmount = current / max;
    }
}