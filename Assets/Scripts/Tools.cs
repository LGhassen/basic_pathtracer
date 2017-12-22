using UnityEngine;
using System.Collections;

public static class Tools
{

	public static Mesh MakePlaneWithFrustumIndexes() //creates a basic quad + frustum corner indexes stored in the vertexes
	//the frustum corner indexes later allow to reconstruct world viewdir inexpensively in the shader
	//by passing the frustum corners directions in world space
	{

		Vector3[] vertices = new Vector3[4];
		Vector2[] texcoords = new Vector2[4];
		int[] indices = new int[6];

		for(int x = 0; x < 2; x++)
		{
			for(int y = 0; y < 2; y++)
			{
				Vector2 uv = new Vector3((float)x , (float)y);
				Vector2 p = new Vector2();

				p.x = (uv.x-0.5f)*2.0f;
				p.y = (uv.y-0.5f)*2.0f;

				Vector3 pos = new Vector3(p.x, p.y, (float)(x + 2*y));

				texcoords[x+y*2] = uv;
				vertices[x+y*2] = pos;
			}
		}

		indices[0] = 0;
		indices[1] = 1;
		indices[2] = 2;

		indices[3] = 2;
		indices[4] = 1;
		indices[5] = 3;

		Mesh mesh = new Mesh();

		mesh.vertices = vertices;
		mesh.uv = texcoords;
		mesh.triangles = indices;

		return mesh;
	}
}

