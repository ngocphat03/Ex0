namespace Script.UIMain
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using Script.GameManager;
    using Script.UIManager;

    public class UIMain : UIManager
    {
        [SerializeField] private Button btnPause;
        [SerializeField] private TextMeshProUGUI timeNow;

        private void Start() {
            this.btnPause.onClick.AddListener(this.Pause);
        }
        
        private void FixedUpdate() {
            this.PrintTimeToScreen();
        }

        private void Pause()
        {
            OpenPausePopup();
            GameManager.Instance.StopGame();
        }

        private void PrintTimeToScreen()
        {
            timeNow.text = GameManager.Instance.ReturnTime();
        }

    }
}