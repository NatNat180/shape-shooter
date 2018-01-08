using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
	Renderer lensRenderer;
	Color lensColor;

    void Start()
    {
		lensRenderer = GetComponentInChildren<Renderer>();
		// set initial alpha color of lens to 0
		lensColor = lensRenderer.material.color;
		lensColor.a = 0;
		lensRenderer.material.color = lensColor;
    }

    void Update()
    {
		if (GameProperties.PlayerHurtSound.isPlaying && Time.timeScale != 0)
		{
			StartCoroutine(Redden());
		}
    }

	IEnumerator Redden()
    {
        // change alpha color of lens from original to transparent red, 
        for (float gradation = 0; gradation <= 0.5f; gradation += 0.05f)
        {
            lensColor.a = gradation;
            lensRenderer.material.color = lensColor;
            yield return null;
        }
		// and back to original
		for (float gradation = 0.5f; gradation >= 0; gradation -= 0.05f)
        {
            lensColor.a = gradation;
            lensRenderer.material.color = lensColor;
            yield return null;
        }
    }
	
}
