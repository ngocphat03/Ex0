
    using Ensign;
    using System.Collections.Generic;
    
    public class UserModel : IDataModel
    {
        public int    score;
        public string name;
    }

    public class ListPlayerModel : IDataModel
    {
        public List<UserModel> ListPlayer;
    }
