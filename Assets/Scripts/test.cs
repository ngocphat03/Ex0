namespace Script.PlayerView
{
    using Ensign;
    using UnityEngine;
    using UnityEngine.UI;
    using Ensign.Unity.MVC;
    using Script.PlayerModel;
    using System.Collections;
    using Script.GameManager;
    using Script.PlayerController;
    using System.Collections.Generic;

    public class test : MonoBehaviour
    {
        
	public Rigidbody rb;
	public float speed;

    public GameObject target;
    public GameObject player;

    private Vector3 movement;
        void FixedUpdate ()
	{
		if(Input.GetKey(KeyCode.W)) 
            { 
                movement += AXitLibrary.DirectionVector(player, target);
            }
		if(Input.GetKey(KeyCode.S)) 
            { 
                movement -= AXitLibrary.DirectionVector(player, target);
            }

		rb.AddForce (movement * speed);
        Resett();
	}
    void Resett()
    {
        movement = new Vector3(0,0,0);
    }
    }
}