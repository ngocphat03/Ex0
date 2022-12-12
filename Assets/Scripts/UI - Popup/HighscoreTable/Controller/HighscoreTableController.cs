namespace Script.HighscoreTableController
{
    using Ensign.Unity.MVC;
    using System;
    using UnityEngine;
    using System.Linq;
    using System.IO;
    using UnityEngine.UI;
    using System.Collections;
    using Script.HighscoreTableModel;    
    using Newtonsoft.Json.Converters;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class HighscoreTableController : Controller<HighscoreTableController, ListHighscore>
    {
        private string path = Application.persistentDataPath + "/dataUser.json";

        protected override void Init()
        {
            base.Init();
            this.Model.ListPlayer = new List<UserModel>();
        }

        public UserModel[] LoadDataToFile()
        {
            //Get list players from file
            var outputJson     = File.ReadAllText(Application.persistentDataPath + "/dataUser.json");
            //Convert to json file
            ListPlayerModel loadedUserData = JsonConvert.DeserializeObject<ListPlayerModel>(outputJson);

            //Sort list players by score 
            var orderByResut = from n in loadedUserData.ListPlayer
                                orderby n.score descending
                                select n;
            var listPlayer = orderByResut.ToArray();
            
            return listPlayer;
        }
    }
}