using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraShake), true)]
public class CameraShakeEditor : Editor {

	public override void OnInspectorGUI (){

		DrawDefaultInspector ();

		CameraShake cameraShake = (CameraShake)target;

		if (GUILayout.Button ("Start")) {
			if (cameraShake.infiniteTime) {
				cameraShake.StartCoroutine (cameraShake.Shake (float.PositiveInfinity, cameraShake.magnitude, cameraShake.smoothTime));
			} else {
				cameraShake.StartCoroutine (cameraShake.Shake (cameraShake.duration, cameraShake.magnitude, cameraShake.smoothTime));			
			}
		}

		if (GUILayout.Button ("STAP! I could've dropped my croissant!")) {
			cameraShake.StopAllCoroutines ();
			cameraShake.isRunning = false;
		}
	}
}
