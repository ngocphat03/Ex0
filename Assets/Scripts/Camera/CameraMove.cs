namespace Script.Camera
{
    using UnityEngine;
    using System.Collections;
    using Script.PlayerView;
    using Script.GameManager;
    using System.Collections.Generic;

    public class CameraMove : MonoBehaviour
    {
        private Vector3 speedRotation = new Vector3(0f, 3f, 0f);
        private float speed = 30f;
        
        private void FixedUpdate () 
        {
            //If gameover we can't move the camera
            if(!GameManager.Instance.ReturnStatusGame()) this.MoveCameraLeftOrRight();
        }

        private void MoveCameraLeftOrRight()
        { 
            if(Input.GetKey(KeyCode.A)) 
            { 
                transform.eulerAngles -= this.speedRotation * Time.deltaTime * this.speed;
            }           
            if(Input.GetKey(KeyCode.D)) 
            { 
                transform.eulerAngles += this.speedRotation * Time.deltaTime * this.speed;
            }
        }
    }
}