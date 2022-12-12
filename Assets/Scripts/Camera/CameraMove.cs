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
        //[SerializeField] private GameObject target;
        private float speed = 10f;
        //public Vector3 cameraDirectionNow;
        //public Vector3 cameraDirectionEntry;
        //public float camDistance;
        //public Vector2 cameraDistanceMinMax = new Vector2(0.5f, 2f);
        //[SerializeField] private  Transform cam;
        private void Start() 
        {

            // this.GetNow();
            // this.GetEntry();
            //camDistance = cameraDistanceMinMax.y;
            // this.GetSpeedRotation();
        }
        
        private void FixedUpdate () 
        {
            //If gameover we can't move the camera
            if(!GameManager.Instance.ReturnStatusGame()) this.MoveCameraLeftOrRight();

            //  GetNow();
            // this.SetTarget(); 
            // this.GetSpeedRotation(); 
            // this.CheckCamera(cam);
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
        

        // private void OnEnable() {
        //     this.GetSpeedRotation();
        // }

        // public void SetTarget()
        // {
        //     transform.position = target.transform.position;
        // }

        // private void GetSpeedRotation()
        // {
        //     this.speedRotation = new Vector3(0f, this.speed * Time.deltaTime, 0f);
        // }

        // private void CheckCamera(Transform cam)
        // {
        //     Vector3 desiredCameraPosition = transform.TransformPoint(cameraDirectionNow * cameraDistanceMinMax.y);
        //     RaycastHit hit;
        //     if(Physics.Linecast(transform.position, desiredCameraPosition, out hit))
        //     {
        //         camDistance =Mathf.Clamp(hit.distance, cameraDistanceMinMax.x, cameraDistanceMinMax.y);
        //         //cam.localPosition = cameraDirectionNow * camDistance;
        //     }
        //     else
        //     {
        //     //cam.localPosition = cameraDirectionNow * camDistance;
        //     //    camDistance = cameraDistanceMinMax.y;
        //     }
        //     this.GetNow();
        //     cam.localPosition = cameraDirectionEntry * camDistance;
        // }

        // private void GetNow()
        // {
        //     cameraDirectionNow = cam.transform.localPosition.normalized;
        // }

        // private void GetEntry()
        // {
        //     cameraDirectionEntry = cam.transform.localPosition.normalized;
        // }
    }
}