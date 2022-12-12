namespace Script.UIManager
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class UIManager : MonoBehaviour
    {
        public void QuitGame()
        {
            Application.Quit();
        }

        public void OpenStartPopup()
        {
            Instantiate(Resources.Load<GameObject>("PopupStart") as GameObject);
        }

        public void OpenPausePopup()
        {
            Instantiate(Resources.Load<GameObject>("PopupPause") as GameObject);
        }

        public void OpenHighScorePopup()
        {
            Instantiate(Resources.Load<GameObject>("PopupHighScore") as GameObject);
        }

        public void OpenResultPopup()
        {
            Instantiate(Resources.Load<GameObject>("InputHighscore") as GameObject);
        }

        public void ClosePopup()
        {
            Destroy(gameObject);
        }
    }    
}