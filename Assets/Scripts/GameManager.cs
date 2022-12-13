namespace Script.GameManager
{
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.SceneManagement;

    public class GameManager : MonoBehaviour
    {
        private float minute = 3f;
        private float second = 0f;

        private bool gameOver = false;
        private string timeNow;
        public static GameManager Instance;

        private void Awake() 
        {
            Instance = this;
            PlayerPrefs.SetInt("highScore", 0); 
        }

        private void Update()
        {
            this.CountDownTime();   
        }

        private void CountDownTime() 
        { 
            if((second <= 0) && (minute > 0)){
                this.minute--;
                this.second = 60f;
            }
            this.second -= Time.deltaTime; 

            if((second <= 0) && (minute <= 0)){
                Debug.Log("Game Over");
                this.StopGame();
                this.EndGame();
            }
        }

        public int TimeIs()
        {
            int timeNowIs = ((int)minute * 60) + ((int)second);
            return timeNowIs;
        }

        public string ReturnTime()
        {
            int secondInt = (int)second;
            if(secondInt < 10)
                timeNow = "Time: " + "0" + minute.ToString() + ":" + "0" + secondInt.ToString();
            else
                timeNow = "Time: " + "0" + minute.ToString() + ":" + secondInt.ToString();
            return timeNow;
        }

        public bool ReturnStatusGame() => this.gameOver;

        public void ChangeStatusGame(){
            this.gameOver = true;
            Debug.Log(gameOver);
        }

        public void EndGame()
        {
            this.StopGame();
            if(this.CheckHighScore())
                Instantiate(Resources.Load<GameObject>("InputHighscore") as GameObject);
            Instantiate(Resources.Load<GameObject>("PopupHighScore") as GameObject);
        }

        public void Output()
        {
            Debug.Log(this.gameOver);
        }

        public void StopGame()
        {
            Time.timeScale = 0f;
        }

        public void StartGame()
        {
            Time.timeScale = 1f;
        }

        private bool CheckHighScore()
        {
            Debug.Log(PlayerPrefs.GetInt("highScore"));
            if((TimeIs() >=  PlayerPrefs.GetInt("highScore")) && (this.gameOver))
            //if(true)
            {
                PlayerPrefs.SetInt("highScore", this.TimeIs()); 
                return true; 
            }
            else
                return false;
        }
        
        public void ResetScene()
        {
            SceneManager.LoadScene(0);
        }
    }    
}