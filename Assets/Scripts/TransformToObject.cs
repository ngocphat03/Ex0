namespace Script.TransformToObject
{
    using UnityEngine;
    using System.Collections;
    
    public class TransformToObject : MonoBehaviour 
    {
        [SerializeField] private GameObject Object;
        [SerializeField] private GameObject Target;

        private void FixedUpdate()
        {
            Object.transform.position = Target.transform.position;
        }
    }
}