namespace Script.ZoneSpeedUp
{
    using UnityEngine;
    using Script.PlayerView;
    using System.Collections;
    using System.Collections.Generic;

    public class ZoneSpeedUp : MonoBehaviour
    {
        private void OnTriggerStay(Collider other) {
            if (other.gameObject.tag == "Player")
            {
                PlayerView.Instance.ChangeMaxSpeed();
            }
        }
    }
}