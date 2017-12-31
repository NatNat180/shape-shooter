using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBehaviour : MonoBehaviour {

	Rigidbody shapeBody;
	Camera mainCamera;
	public GameObject particleObject;
	ParticleSystem particleSys;
	Renderer particleRend;
	Renderer shapeRend;

	void Start() 
	{
		shapeBody = GetComponent<Rigidbody>();
		mainCamera = GameObject.Find("MainCam").GetComponent<Camera>();
		particleSys = particleObject.GetComponent<ParticleSystem>();
		particleRend = particleSys.GetComponent<Renderer>();
		shapeRend = gameObject.GetComponent<Renderer>();
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
			particleRend.material = shapeRend.material;
			Instantiate(particleObject, transform.position, Quaternion.identity);
			Destroy(gameObject);
			GameProperties.PlayerScore += 10;
		}
	}

}
