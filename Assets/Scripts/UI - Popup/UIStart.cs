namespace Script.UIStart
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Script.GameManager;
    using Script.UIManager;
    using UnityEngine.UI;

    public class UIStart : UIManager
    {
        [SerializeField] private Button btnStart;
        [SerializeField] private Button btnHighScore;
        [SerializeField] private Button btnExit;

        private void Start() {
            btnStart.onClick.AddListener(this.StartGame);
            btnHighScore.onClick.AddListener(this.HighScore);
            btnExit.onClick.AddListener(QuitGame);
            GameManager.Instance.StopGame();
        }

        private void OnDisable() {
            GameManager.Instance.StartGame();
        }
        
        private void StartGame()
        {
            ClosePopup();
            GameManager.Instance.StartGame();
        }

        private void HighScore()
        {
            OpenHighScorePopup();
            GameManager.Instance.StopGame();
        }
    }
}