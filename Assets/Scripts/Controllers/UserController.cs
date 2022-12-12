namespace Script.User
{
    using System.IO;
    using UnityEngine;
    using Ensign.Unity.MVC;
    using System.Collections.Generic;
    public class UserController : Controller<UserController, UserModel>
    {
        private string path = Application.persistentDataPath + "/dataUser.json";
        string data;

        private void CreateEmptyData()
        {
            string empty = "{\"ListPlayer\":[]}";
            File.WriteAllText(this.path, empty);
        }
        
        public void CheckFile()
        {
            if (!File.Exists(path))
                this.CreateEmptyData(); 
            this.CheckData();
            if(this.data == "") 
                this.CreateEmptyData();
        }
        
        private void CheckData()
        {
            this.data = File.ReadAllText(Application.persistentDataPath + "/dataUser.json");
        }
    }
}