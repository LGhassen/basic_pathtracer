using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Material PathTracerMaterial, ResolveMaterial;
	public RenderTexture renderBuffer, copyBuffer;

	public int totalFrames=1;

	public Camera mainCamera;

	//controller
	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 40.0f;
	private float pitch = 0.0f;

	private float yawDelta=0f;
	private float pitchDelta=0f;

	public int inputSamples = 0;
	public int currentSamples = 0;

	Transform aparentTransform;

	// Use this for initialization
	void Start ()
	{
		GameObject originGO = new GameObject();
		aparentTransform = originGO.transform;
		aparentTransform.position = Vector3.zero;
		aparentTransform.localScale = Vector3.one;
		transform.SetParent (aparentTransform);
		aparentTransform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
	}

	public void ClearRenderBuffer()
	{
		RenderTexture rt=RenderTexture.active;
		RenderTexture.active= renderBuffer;			
		GL.Clear(false,true,Color.black);
		RenderTexture.active=rt;	
	}
		

	void OnPreCull()
	{
		if (Input.GetMouseButton (1))
		{
			
			yawDelta = speedH * Input.GetAxis ("Mouse X");
			pitchDelta = speedV * Input.GetAxis ("Mouse Y");

			if ((yawDelta!= 0f) ||(pitchDelta!= 0f))
			{
				yaw += yawDelta;
				pitch -= pitchDelta;

			//quick hardcoded rotation limits
//			yaw   = Mathf.Clamp (yaw  , 21.5f, 58.5f);
//			pitch = Mathf.Clamp (pitch, -17.0f, 17.0f);

			aparentTransform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

			totalFrames = 1;
			ClearRenderBuffer ();
			}
		}
		else
		{
			currentSamples = inputSamples;
		}


		//update stuff
		if (PathTracerMaterial && ResolveMaterial)
		{
			Vector3 topLeft = mainCamera.ViewportPointToRay (new Vector3 (0f, 1f, 0f)).direction;
			topLeft.Normalize ();

			Vector3 topRight = mainCamera.ViewportPointToRay (new Vector3 (1f, 1f, 0f)).direction;
			topRight.Normalize ();

			Vector3 bottomRight = mainCamera.ViewportPointToRay (new Vector3 (1f, 0f, 0f)).direction;
			bottomRight.Normalize ();

			Vector3 bottomLeft = mainCamera.ViewportPointToRay (new Vector3 (0f, 0f, 0f)).direction;
			bottomRight.Normalize ();

			Matrix4x4 _frustumCorners = Matrix4x4.identity;

			_frustumCorners.SetRow (0, bottomLeft); 
			_frustumCorners.SetRow (1, bottomRight);		
			_frustumCorners.SetRow (2, topLeft);
			_frustumCorners.SetRow (3, topRight);	

			PathTracerMaterial.SetMatrix ("FrustumCorners", _frustumCorners);
			ResolveMaterial.SetInt    ("TotalFrames", totalFrames);

			PathTracerMaterial.SetInt ("SAMPLES", currentSamples);
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnPreRender()
	{
	}		

	void OnPostRender()
	{
		totalFrames++;
	}
		
	void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
//		Graphics.Blit(renderBuffer, dest);
//		Graphics.Blit (src,null, PathTracerMaterial);
//		PathTracerMaterial.mainTexture= src;
//		PathTracerMaterial.SetTexture("_MainTex",renderBuffer);
//		Graphics.Blit (null,dest, PathTracerMaterial);
//		Graphics.Blit (dest,renderBuffer);
//		PathTracerMaterial.SetTexture("_MainTex",src);
//		Graphics.Blit (null,dest, PathTracerMaterial);


//		//flips the UVs:
//		//////////////////////////////////////////////////////////////
//		PathTracerMaterial.SetTexture("_MainTex",renderBuffer);
//		//blit to screen
//		Graphics.Blit (null,dest, PathTracerMaterial);
//		//copy results to buffer
//		Graphics.Blit (dest, renderBuffer);
//		//////////////////////////////////////////////////////////////


		//PathTracerMaterial.SetTexture("_MainTex",copyBuffer);

        Graphics.Blit (null,renderBuffer, PathTracerMaterial);
//        Graphics.Blit(renderBuffer, copyBuffer);
		ResolveMaterial.SetTexture("_MainTex",renderBuffer);
		Graphics.Blit (renderBuffer,dest, ResolveMaterial);

        //Graphics.Blit(null, dest, PathTracerMaterial);
    }
}
