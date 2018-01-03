﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Setup : MonoBehaviour {

	[SerializeField]
	Camera mainCamera;

	[SerializeField]
	int samples;

	[SerializeField]
	int bounces;

	[SerializeField]
	float supersamplingFactor;

	CameraScript cameraScript;

	Rect windowRect = new Rect (0, 0, 400, 50);
	int windowId = 0;

	[SerializeField]
	Material PathTracerMaterial;

	RenderTexture renderBuffer, copyBuffer;

	// Use this for initialization
	void Start ()
	{
		if (mainCamera)
		{
			mainCamera.clearFlags = CameraClearFlags.Nothing;
			//mainCamera.backgroundColor = Color.black;

			if (PathTracerMaterial)
			{
				Debug.Log ("PathTracerMaterial found");
				Vector2 _resolution = new Vector2(Screen.width, Screen.height);
				PathTracerMaterial.SetVector ("Resolution", _resolution);
				Debug.Log ("screen resolution: " + _resolution.ToString ());
				PathTracerMaterial.SetInt ("SAMPLES", samples);
				PathTracerMaterial.SetInt ("MAX_DEPTH", bounces);
			}

			renderBuffer = new RenderTexture ((int) (Screen.width * supersamplingFactor), (int) (Screen.height * supersamplingFactor) , 0, RenderTextureFormat.ARGB32);
			renderBuffer.anisoLevel = 0;
			renderBuffer.autoGenerateMips = false;
			renderBuffer.filterMode = FilterMode.Trilinear;
			renderBuffer.useMipMap = false;

			renderBuffer.Create ();

			copyBuffer = new RenderTexture ((int) (Screen.width * supersamplingFactor), (int) (Screen.height * supersamplingFactor), 0, RenderTextureFormat.ARGB32);
			copyBuffer.anisoLevel = 0;
			copyBuffer.autoGenerateMips = false;
			copyBuffer.filterMode = FilterMode.Trilinear;
			copyBuffer.useMipMap = false;

			copyBuffer.Create ();

			cameraScript = (CameraScript) mainCamera.gameObject.AddComponent (typeof(CameraScript));
			cameraScript.renderBuffer = renderBuffer;
			cameraScript.copyBuffer   = copyBuffer;
			cameraScript.mainCamera   = mainCamera;
			cameraScript.inputSamples = samples;

			cameraScript.PathTracerMaterial = PathTracerMaterial;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnGUI ()
	{
		windowRect = GUILayout.Window (windowId, windowRect, DrawWindow,"Basic pathtracer");

		//prevent window from going offscreen
		windowRect.x = Mathf.Clamp(windowRect.x,0,Screen.width-windowRect.width);
		windowRect.y = Mathf.Clamp(windowRect.y,0,Screen.height-windowRect.height);

	}

	void DrawWindow(int windowId)
	{
		GUILayout.Label (String.Format ("Samples per pixel: "+(cameraScript.currentSamples * cameraScript.totalFrames).ToString()));
		GUILayout.Label (String.Format ("Supersampling factor: "+supersamplingFactor.ToString()));
		GUILayout.Label (String.Format ("Bounces: "+bounces.ToString()));
		if (GUILayout.Button ("Save to PNG"))
		{
			SaveToPNG ();
		}
		GUI.DragWindow();
	}

	void SaveToPNG()
	{
		Texture2D screenshot = new Texture2D((int) (Screen.width * supersamplingFactor), (int) (Screen.height * supersamplingFactor), TextureFormat.RGB24, false);

		RenderTexture.active = copyBuffer;
		screenshot.ReadPixels( new Rect(0, 0, (int) (Screen.width * supersamplingFactor), (int) (Screen.height * supersamplingFactor)), 0, 0);

		//screenshot.Resize(Screen.width, Screen.height);
		RenderTexture.active = null;

		byte[] bytes;
		bytes = screenshot.EncodeToPNG();

		string screenshotFileName = "/S_" + System.DateTime.Now.ToString ("_yyyy-MM-dd-hh-mm-ss") +"_spp"+(samples * cameraScript.totalFrames).ToString()+"_ss"+supersamplingFactor.ToString()+ ".png";

		System.IO.File.WriteAllBytes(Application.dataPath + screenshotFileName, bytes);
		Debug.Log ("PNG saved to " + Application.dataPath + screenshotFileName);
	}
}
