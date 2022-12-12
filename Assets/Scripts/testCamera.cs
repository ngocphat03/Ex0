
    using UnityEngine;
    using System.Collections;
    using Script.PlayerView;
    using System.Collections.Generic;

    public class testCamera : MonoBehaviour
    {
        // [SerializeField] private GameObject target;
        public float speed = 70f;
        private Vector3 speedRotation = new Vector3(0f, 3f, 0f);
        private void Start() 
        {
        }
        
        private void Update () 
        {
           // this.SetTarget(); 
            if(Input.GetKey(KeyCode.A)) 
            { 
                transform.eulerAngles -= this.speedRotation;
            }           
            if(Input.GetKey(KeyCode.D)) 
            { 
                transform.eulerAngles += this.speedRotation;
            }
        }

        // public void SetTarget()
        // {
        //     transform.position = target.transform.position;
        // }
    }
