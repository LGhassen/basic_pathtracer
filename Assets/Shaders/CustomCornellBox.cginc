// Rotated cornell box description with spheres and red/green walls
#define NUMBER_OF_OBJECTS 12
#define EXPLICIT_LIGHT_SAMPLING   //better used with small lights
#define LIGHTSOURCE_INDEX 6 //for explicit light sampling
static object objects[NUMBER_OF_OBJECTS]=
{
	{float3(-76645.1, 0.0, 64312.8),1e5,float3(0.75,0.26,0.26),float3(0.0,0.0,0.0), DIFFUSE, SPHERE}, //left
	{float3(76645.1, 0.0, -64312.8),1e5,float3(0.26,0.75,0.26),float3(0.0,0.0,0.0), DIFFUSE, SPHERE}, //right
	{float3(64331.5, 0.0, 76667.3),1e5,float3(0.75,0.75,0.75),float3(0.0,0.0,0.0), DIFFUSE, SPHERE}, //back
	{float3(-64407.3, 0.0, -76757.7),1e5,float3(0.75,0.75,0.75),float3(0.0,0.0,0.0), DIFFUSE, SPHERE}, //front

	{float3(	0.0,     1e5+50, 		0.0),1e5,float3(0.75,0.75,0.75),float3(0.0,0.0,0.0), DIFFUSE, SPHERE}, //top
	{float3(	0.0,    -1e5-50, 		0.0),1e5,float3(0.75,0.75,0.75),float3(0.0,0.0,0.0), DIFFUSE, SPHERE}, //bottom

	//{float3(	0.0,    649.0, 		0.0),600.0,float3(1.0,1.0,1.0),float3(8.0,8.0,8.0), DIFFUSE, SPHERE}, //light    //large, use without EXPLICIT_LIGHT_SAMPLING
	{float3(	0.0,    30.0, 		0.0),5.0,float3(1.0,1.0,1.0),float3(80.0,80.0,80.0), DIFFUSE, SPHERE}, //light  //small, use with EXPLICIT_LIGHT_SAMPLING

	{float3(5.5, -5.7, 42.6),16.5,float3(1.0,1.0,1.0),float3(0.0,0.0,0.0), MIRROR, SPHERE}, //left mirror sphere
	{float3(5.5, -36.2, 42.6),14.0,float3(0.75,0.75,0.75),float3(0.0,0.0,0.0), DIFFUSE, BOX},	//left box

	{float3(24.0, -36.2, -12.0),14.0,float3(0.75,0.75,0.75),float3(0.0,0.0,0.0), DIFFUSE, BOX},	//right, lower box
	{float3(24.0, -8.2, -12.0),14.0,float3(0.75,0.75,0.75),float3(0.0,0.0,0.0), DIFFUSE, BOX},	//right, upper box
	{float3(-19.0, -33.5, -15.0),16.5,float3(1.0,1.0,1.0),float3(0.0,0.0,0.0), GLASS, SPHERE}	//center sphere
};