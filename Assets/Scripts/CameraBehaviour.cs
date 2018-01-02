using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    float shakeDuration;
    float shakeMagnitude;
	Vector3 originalCamPos;
	Renderer lensRenderer;
	Color lensColor;

    void Start()
    {
		originalCamPos = Camera.main.transform.position;
		shakeDuration = 0.1f;
		shakeMagnitude = 0.5f;
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
			StartCoroutine(Shake());
			StartCoroutine(Redden());
		}
    }

    IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / shakeDuration;
			// 'dampen' shake animation as shake animation nears 100 percent completion
            float damper = 1.0f - Mathf.Clamp(5.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // create random x and y offsets from original cam position
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= shakeMagnitude * damper;
            y *= shakeMagnitude * damper;
				
            Camera.main.transform.position = new Vector3(x, y, originalCamPos.z);

            yield return null;
        }

        Camera.main.transform.position = originalCamPos;

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
