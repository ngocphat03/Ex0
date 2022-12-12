namespace Script.ZoneSpeedUp
{
    using UnityEngine;
    using Script.PlayerView;
    using System.Collections;
    using System.Collections.Generic;

    public class ZoneSpeedUp : MonoBehaviour
    {
        private void OnCollisionStay(Collision other)
        {
            // Debug.Log("Other trigger");
            // if (other.gameObject.tag == "Player")
            // {
            //     Debug.Log("Player trigger");
            //     PlayerView.Instance.ChangeMaxSpeed();
            // }
        }
        private void OnTriggerStay(Collider other) {
            Debug.Log("Other trigger");
            if (other.gameObject.tag == "Player")
            {
                Debug.LogError("Player trigger");
                PlayerView.Instance.ChangeMaxSpeed();
            }
        }
    }
}