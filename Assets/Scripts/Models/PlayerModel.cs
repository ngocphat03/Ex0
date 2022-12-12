namespace Script.PlayerModel
{
    using Ensign;
    using UnityEngine;
    using Ensign.Unity.MVC;
    using System.Collections;

    public class PlayerModel : IDataModel
    {
        public float speed;
        public float defaultSpeed;
        public float maxSpeed;
        public float strength;
        public Vector3 movement;
        public Vector3 rotation;
        public Vector3 speedRotation;
        public Vector3 speedOfMovement;
        public bool inPlace;
    }
}