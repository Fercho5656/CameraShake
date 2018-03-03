using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	[Header("Values")]
	public float duration;
	[Range(1f,10f)]
	public float magnitude;
	[Range(0f,1f)]
	public float smoothTime;
	[Header("Booleans")]
	[HideInInspector]
	public bool isRunning;
	public bool infiniteTime;

	public void Update(){
		if (Input.GetKeyDown (KeyCode.Space) && !isRunning) {
			if (infiniteTime) {
				StartCoroutine (Shake (float.PositiveInfinity, magnitude, smoothTime));
			} else {
				StartCoroutine (Shake (duration, magnitude, smoothTime));
			}
		}
	}

	public IEnumerator Shake(float duration, float magnitude, float smoothTime){
		isRunning = true;

		Vector3 originalPosition = transform.localPosition;
		Quaternion originalRotation = transform.localRotation;

		Vector3 velocity = Vector3.zero;

		float elapsed = 0.0f;

		while (elapsed < duration) {
			float x = Random.Range (originalPosition.x - 1f, originalPosition.x + 1f) * magnitude;
			float y = Random.Range (originalPosition.y - 1f, originalPosition.y + 1f) * magnitude;
			//float z = Random.Range (originalRotation.z - 0.1f, originalRotation.z + 0.1f) * magnitude;

			Vector3 randomPosition = new Vector3 (x, y, originalPosition.z);
			//Quaternion randomRotation = new Quaternion (originalRotation.x, originalRotation.y, z, 1f);

			gameObject.transform.localPosition = Vector3.SmoothDamp (originalPosition, randomPosition, ref velocity, smoothTime);
			//gameObject.transform.localRotation = Quaternion.RotateTowards (originalRotation, randomRotation, 0.1f);

			elapsed += Time.deltaTime;

			yield return null;
		}

		isRunning = false;

		gameObject.transform.localPosition = originalPosition;
		gameObject.transform.localRotation = originalRotation;
	}
}
