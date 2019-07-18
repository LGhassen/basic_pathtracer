# basic_pathtracer

An unbiased Monte Carlo pathtracer running on the GPU in unity. Inspired by smallpt, done as a learning project.

All scene rendering is done in a shader, renderer is very fast compared to similar CPU pathtracers.

Rendering can be sped up by activating explicit light sampling in cases where the light source is small.

Supports supersampling.

Camera can be rotated by holding down the right mouse button and panning.

Can render spheres and boxes.

You can run the WebGL version here: http://lghassen.github.io/pathtracer.html

The following scenes are rendered in between 20-40 seconds on a GTX 1060 3GB:

<p align="center"><img src="https://github.com/LGhassen/basic_pathtracer/blob/master/img/7.jpg" ></p>

<p align="center"><img src="https://github.com/LGhassen/basic_pathtracer/blob/master/img/1.jpg" ></p>

<p align="center"><img src="https://github.com/LGhassen/basic_pathtracer/blob/master/img/2.jpg" ></p>

<p align="center"><img src="https://github.com/LGhassen/basic_pathtracer/blob/master/img/3.jpg" ></p>

<p align="center"><img src="https://github.com/LGhassen/basic_pathtracer/blob/master/img/4.jpg" ></p>

<p align="center"><img src="https://github.com/LGhassen/basic_pathtracer/blob/master/img/5.jpg" ></p>

<p align="center"><img src="https://github.com/LGhassen/basic_pathtracer/blob/master/img/6.jpg" ></p>

## Notes
-Arbitrary box rotation is not implemented because the code used only handles axis-aligned bounding-boxes (can be added to the existing code by multiplying the rayDir with the box rotation matrix).

-Explicit light sampling was partially implemented, currently not implemented for box light sources. May affect scene look.
