namespace Script.PlayerController
{
    using Ensign;
    using UnityEngine;
    using Ensign.Unity.MVC;
    using Script.PlayerModel;
    using System.Collections;
    using System.Collections.Generic;

    public class PlayerController : Controller<PlayerController, PlayerModel>
    {
        protected override void Init()
        {
            base.Init();

            this.ChangeModel(new PlayerModel
            {
                speed           = 1f,
                defaultSpeed    = 1f,
                maxSpeed        = 3f,
                strength        = 100f,
                movement        = default,
                rotation        = default,
                speedOfMovement = default,
                speedRotation   = new Vector3(0f, 70f * Time.deltaTime, 0f),
                inPlace         = false,
            });
        }
    
        public void ResetMovement()
        {
            this.Model.movement = Vector3.zero; 
        }

        public void ChangeSpeedPlayer() 
        { 
            this.Model.maxSpeed = 5f; 
            Debug.Log("Max speed aplayer controller" + this.Model.maxSpeed);
        }

        public void ChangeSpeedToDefault()
        {
            if(this.Model.speed > this.Model.defaultSpeed)
            {
                this.Model.speed -= Time.deltaTime * 1f;
            }
        }

        public void InPlane()
        {
            this.Model.inPlace = true;
        }

        public void OutPlane()
        {
            this.Model.inPlace = false;
        }
    }
}
