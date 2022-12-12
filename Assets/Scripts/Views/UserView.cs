namespace Script.User
{
    using UnityEngine;
    using Ensign.Unity.MVC;

    public class UserView : View<UserController, UserModel>
    { 
        private void Awake() {
            this.Controller.CheckFile();
        }
    }
}