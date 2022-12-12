namespace Script.LookAtForObject
{
    using UnityEngine;

    public class LookAtForObject : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        
        void LateUpdate() 
        {
            transform.LookAt(target.transform);
        }
    }
}
