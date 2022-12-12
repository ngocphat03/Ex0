namespace Script.HighscoreTableView
{
    using TMPro;
    using Ensign;
    using System.IO;
    using UnityEngine;
    using System.Linq;
    using UnityEngine.UI;
    using Newtonsoft.Json;
    using Ensign.Unity.MVC;
    using System.Collections;
    using Script.GameManager;
    using Script.HighscoreTableModel;
    using System.Collections.Generic;
    using Script.HighscoreTableController;

    public class HighscoreTableView : View<HighscoreTableController, ListHighscore>
    {
        [SerializeField] private Button btnOk;
        [SerializeField] private TextMeshProUGUI scoreNow;
        [SerializeField] private TextMeshProUGUI gameWinOrLose;
        [SerializeField] private GameObject player;
        [SerializeField] private Transform parent;
        [SerializeField] private TextMeshProUGUI listPlayerName;
        [SerializeField] private TextMeshProUGUI listPlayerScore;
        [SerializeField] private GameObject popupStart;
        private UserModel[] listPlayerData;
        private int listCount = 5;

        public static HighscoreTableView Instance;

        private void Awake() {
            Instance = this;
        }

        private void Start() {
            this.btnOk.onClick.AddListener(ClosePopup);
            this.PrintScoreToScreen();
            this.GameWinOrLose();
            this.CreateListPlayer();
            this.popupStart = GameObject.FindWithTag("PopupStart");
        }

        private void Update() {
            this.GetData();
        }

        private void OnEnable() {
            GameManager.Instance.StopGame();
        }

        private void PrintScoreToScreen()
        {
            GameManager.Instance.Output();
            if(GameManager.Instance.ReturnStatusGame())
                this.scoreNow.text = "Your score: " + GameManager.Instance.TimeIs();
            else
                this.scoreNow.text = "Your score: 0";
        }

        private void ClosePopup()
        {
            Destroy(gameObject);
            GameManager.Instance.ResetScene();
        }

        private void GameWinOrLose()
        {
            if(GameManager.Instance.ReturnStatusGame())
                this.gameWinOrLose.text = "Win";
            else
                this.gameWinOrLose.text = "Lose";
        }

        public void GetData()
        {
            this.listPlayerData = this.Controller.LoadDataToFile();
        }

        private void CreateListPlayer()
        {
            this.GetData();
            //Check length array
            if(listPlayerData.Count() < 5) { listCount = listPlayerData.Count(); }

            //Create list player
            for(int i=0; i < listCount; i++)
            {
                listPlayerScore.text = listPlayerData[i].score.ToString();
                listPlayerName.text = listPlayerData[i].name;
                Instantiate(player, transform.position - new Vector3(0, 0, 0), transform.rotation ,parent);
            }
        }

        public void ReloadPopup()
        {
            Destroy(gameObject);
            Instantiate(Resources.Load<GameObject>("PopupHighScore") as GameObject);
        }
    }
}