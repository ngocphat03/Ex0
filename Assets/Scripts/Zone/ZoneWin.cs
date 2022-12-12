namespace Script.ZoneWin
{
    using UnityEngine;
    using Script.GameManager;
    using System.Collections;
    using System.Collections.Generic;

    public class ZoneWin : MonoBehaviour 
    {
        private void OnTriggerEnter(Collider other) 
        {
            Debug.Log("HH");
            GameManager.Instance.ChangeStatusGame();
            GameManager.Instance.EndGame();
        }
    }
}