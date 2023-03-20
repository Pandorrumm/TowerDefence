using TMPro;
using UnityEngine;

namespace TowerDefence.UI
{
    public class WaveCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text waveCounterText;

        public void UpdateWaveCounterText(int _value) => 
            waveCounterText.text = _value.ToString();
    }
}
