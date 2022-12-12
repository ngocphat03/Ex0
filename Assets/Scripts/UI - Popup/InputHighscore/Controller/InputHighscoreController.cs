namespace Script.InputHighscoreController
{
    using Ensign.Unity.MVC;
    using System;
    using UnityEngine;
    using System.Linq;
    using System.IO;
    using UnityEngine.UI;
    using System.Collections;
    using Script.InputHighscoreModel;    
    using Newtonsoft.Json.Converters;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class InputHighscoreController : Controller<InputHighscoreController, ListHighscorePlayer>
    {
        private string path = Application.persistentDataPath + "/dataUser.json";

        protected override void Init()
        {
            base.Init();
            this.Model.ListPlayer = new List<UserModel>();
        }

        public void SaveDataToFile()
        {
            var serializer = new JsonSerializer();
            using var sw = new StreamWriter(Application.persistentDataPath + "/dataUser.json");
            using JsonWriter writer = new JsonTextWriter(sw);
            serializer.Serialize(writer, this.Model);
            Debug.Log("Save success");
        }


        public void LoadDataToFile()
        {
            var outputJson     = File.ReadAllText(Application.persistentDataPath + "/dataUser.json");
            ListPlayerModel loadedUserData = JsonConvert.DeserializeObject<ListPlayerModel>(outputJson);
            this.Model.ListPlayer = loadedUserData.ListPlayer;
        }
    }
}