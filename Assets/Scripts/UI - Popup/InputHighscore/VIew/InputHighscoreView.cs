namespace Script.InputHighscoreView
{
    using TMPro;
    using Ensign;
    using UnityEngine;
    using UnityEngine.UI;
    using Ensign.Unity.MVC;
    using System.Collections;
    using Script.GameManager;
    using Script.HighscoreTableView;
    using Script.InputHighscoreModel;
    using Script.InputHighscoreController;

    public class InputHighscoreView : View<InputHighscoreController, ListHighscorePlayer>
    {
        [SerializeField] private Button btnSave;
        [SerializeField] private TMP_InputField inputName;
        [SerializeField] private TextMeshProUGUI scoreNow;

        private void Start() {
            this.btnSave.onClick.AddListener(SaveData);
            this.PrintScoreToScreen();
            this.CheckInputFieldHaveText();
        }

        private void Update() {
            this.CheckInputFieldHaveText();
        }

        private void SaveData()
        {
            this.Controller.LoadDataToFile();
            this.Model.ListPlayer.Add( new UserModel
            {
                name = inputName.text,
                score = GameManager.Instance.TimeIs(),
            });
            this.Controller.SaveDataToFile();
            this.ClosePopup();
            HighscoreTableView.Instance.ReloadPopup();
        }

        private void PrintScoreToScreen()
        {
            this.scoreNow.text = "Your score is: " + GameManager.Instance.TimeIs();
        }

        private void ClosePopup()
        {
            Destroy(gameObject);
        }

        private void CheckInputFieldHaveText()
        {
            if(inputName.text == "")
                btnSave.interactable = false;
            else
                btnSave.interactable = true;
        }
    }
}