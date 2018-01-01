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
    AudioSource destroySoundSource;

	void Start() 
	{
		shapeBody = GetComponent<Rigidbody>();
		mainCamera = GameObject.Find("MainCam").GetComponent<Camera>();
		particleSys = particleObject.GetComponent<ParticleSystem>();
		particleRend = particleSys.GetComponent<Renderer>();
		shapeRend = gameObject.GetComponent<Renderer>();
		destroySoundSource = GetComponent<AudioSource>();
	}
	
	void Update() 
	{
		transform.Translate(Vector3.back * GameProperties.Speed * Time.deltaTime);
		if (shapeBody.position.z < mainCamera.transform.position.z)
		{
			GameProperties.PlayerHurtSound.Play();
			Destroy(gameObject);
			GameProperties.PlayerHealth -= 1;
		}
	}

	void OnMouseDown()
	{
		// If the game is not paused
		if (Time.timeScale == 1)
		{
			// Increase player score
			GameProperties.PlayerScore += 10;

			// Make particle effect material same as shape material, and instantiate particles
			particleRend.material = shapeRend.material;
			Instantiate(particleObject, transform.position, Quaternion.identity);

			// Play destroy audio clip,
			destroySoundSource.Play();
			// move shape object far away (to avoid multiple clicking),
			transform.position = Vector3.one * 9999999f;
			// and destroy object after audio is finished playing
			Destroy(gameObject, destroySoundSource.clip.length);
		}
	}

}
