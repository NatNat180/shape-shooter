using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRepeating : MonoBehaviour {

	public GameObject shape;
	float spawnRate;

	void Start() 
	{
		/* repeat spawn method, starting at random range between 1 and 3 seconds
		   and subsequently repeating at random range between 1 and 3 seconds
		 */
		InvokeRepeating("SpawnShape", Random.Range(1f, 3f), Random.Range(1f, 3f));
	}
	
	void SpawnShape() 
	{
		float x = Random.Range(transform.localScale.x, -transform.localScale.x);
		float y = Random.Range(transform.localScale.y, transform.position.y + 1);
		Instantiate(shape, new Vector3(x, y, transform.position.z), Quaternion.identity);
	}
}
