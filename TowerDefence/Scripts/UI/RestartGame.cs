using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

namespace TowerDefence.UI
{
    [RequireComponent(typeof(Button))]
    public class RestartGame : MonoBehaviour
    {
        private Button restartButton;

        private void Start()
        {
            restartButton = GetComponent<Button>();
            restartButton.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            DOTween.KillAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}