namespace Script.PlayerView
{
    using Ensign;
    using UnityEngine;
    using UnityEngine.UI;
    using Ensign.Unity.MVC;
    using Script.PlayerModel;
    using System.Collections;
    using Script.GameManager;
    using Script.PlayerController;
    using System.Collections.Generic;

    public class PlayerView : View<PlayerController, PlayerModel>
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private GameObject target;
        [SerializeField] private GameObject player;
        public static PlayerView Instance;

        private void Awake() 
        { 
            Instance = this; 
        }

        private void Update() {
            
            this.Controller.ReduceSpeedToZero();
        }
        private void FixedUpdate() 
        { 
            this.MovePlayerWithKey();
            this.CheckAndResetSpeed();
        }

        private void MovePlayerWithKey() 
        {
            this.GetDirectionVector();
            this.Controller.ResetMovement();
            //Move player to top
            if(Input.GetKey(KeyCode.W)) 
            { 
                this.Controller.ReduceSpeedToDefaut();
                this.Model.movement += (this.Model.speedOfMovement * this.Model.speed) * this.Model.gravitationalAcceleration; 
            }
            //Move player to bottom
            if(Input.GetKey(KeyCode.S)) 
            { 
                this.Controller.ReduceSpeedToDefaut();
                this.Model.movement -= (this.Model.speedOfMovement * this.Model.speed) * this.Model.gravitationalAcceleration; 
            }
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if(rb.velocity != Vector3.zero && this.Model.inPlace)
                {
                    rb.velocity = AXitLibrary.DirectionVector(player, target) * this.Model.speed;
                }
            }
            //Jump
            if(Input.GetKey(KeyCode.Space)) 
            { 
                if(this.Model.inPlace)
                {
                    rb.AddForce(new Vector3(0f, this.Model.strength, 0f)); 
                }
            }

            rb.AddForce(this.Model.movement);
            this.Model.movement = Vector3.zero;
        }

        public void ChangeMaxSpeed() 
        { 
            Debug.Log("Player view"); 
            this.Controller.ChangeSpeedPlayer(); 
        }

        private void CheckAndResetSpeed()
        {
            this.Controller.ChangeSpeedToDefault();
        }

        private void GetDirectionVector()
        {
            this.Model.speedOfMovement = AXitLibrary.DirectionVector(this.player, this.target) * this.Model.speed; 
        }

        private void OnCollisionEnter(Collision other) {
            if((other.gameObject.tag == "Wall"))
                GameManager.Instance.EndGame();
        }
        private void OnCollisionStay(Collision other)
        {
            if((other.gameObject.tag == "Plane")){
                this.Controller.InPlane();
            }
        }
        private void OnCollisionExit(Collision other)
        {
            if((other.gameObject.tag == "Plane")) {   
                this.Controller.OutPlane();   
            }
        }
    }
}