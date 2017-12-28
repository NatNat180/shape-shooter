using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBehaviour : MonoBehaviour {

	Rigidbody shapeBody;
	Camera mainCamera;

	void Start() 
	{
		shapeBody = GetComponent<Rigidbody>();
		mainCamera = GameObject.Find("MainCam").GetComponent<Camera>();
	}
	
	void Update() 
	{
		transform.Translate(Vector3.back * GameProperties.Speed * Time.deltaTime);
		if (shapeBody.position.z < mainCamera.transform.position.z)
		{
			Destroy(gameObject);
			GameProperties.PlayerHealth -= 1;
		}
	}

	void OnMouseDown()
	{
		if (Time.timeScale == 1)
		{
			Destroy(gameObject);
			GameProperties.PlayerScore += 10;
		}
	}

}
