namespace Script.UIPause
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Script.GameManager;
    using Script.UIManager;
    using UnityEngine.UI;

    public class UIPause : UIManager
    {
        [SerializeField] Button btnResume;
        [SerializeField] Button btnExit;

        private void Start() {
            this.btnResume.onClick.AddListener(this.ClosePopup);
            this.btnExit.onClick.AddListener(this.Exit);
        }

        private void OnEnable() {
            GameManager.Instance.StopGame();
        }

        private void OnDisable() {
            GameManager.Instance.StartGame();
        }

        private void Resume()
        {
            ClosePopup();
        }

        private void Exit()
        {
            ClosePopup();
            GameManager.Instance.ResetScene();
        }
    }
}