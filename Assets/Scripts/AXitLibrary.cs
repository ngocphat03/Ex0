using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AXitLibrary : MonoBehaviour
{
    public static Vector3 DirectionVector(GameObject player, GameObject target)
    {
        Vector3 playerPos  =  player.transform.position;
        Vector3 targetPos  =  target.transform.position;
        return new Vector3(targetPos.x - playerPos.x, targetPos.y - playerPos.y, targetPos.z - playerPos.z);
    }
}
