namespace Script.FixCamerFrontWall
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class FixCameraFrontWall : MonoBehaviour
    {
        [SerializeField] private  Transform cam;
        [SerializeField] private  Transform target;
        Vector3 cameraDirection;
        public Vector2 cameraDistanceMinMax = new Vector2(0.5f, 5f);

        public float camDistance;

        private void Start() 
        {
            cameraDirection =  transform.localPosition.normalized;
            camDistance = cameraDistanceMinMax.y;
        }
        private void FixedUpdate() {
            this.CheckCamera(cam);
        }
        private void CheckCamera(Transform cam)
        {
            Vector3 desiredCameraPosition = transform.TransformPoint(cameraDirection * 3);
            RaycastHit hit;
            if(Physics.Linecast(transform.position, desiredCameraPosition, out hit))
            {
                Debug.Log("ee");
                //camDistance =Mathf.Clamp(hit.distance * 0.9f, cameraDistanceMinMax.x, cameraDistanceMinMax.y);
                //camDistance = hit.point;
                //cam.localPosition = cameraDirectionNow * camDistance;
                cam.transform.position = target.transform.position;
            }
            else
            {
                camDistance = cameraDistanceMinMax.y;
            }
            cam.transform.localPosition = cameraDirection * (camDistance    ) ;
        }
    }   
}