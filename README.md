# basic_pathtracer

A basic GPU pathtracer in unity inspired by smallpt, done as a learning project.

All scene rendering is done in a shader, renderer is very fast compared to similar CPU pathtracers.

Can render spheres and boxes.

<p align="center"><img src="https://github.com/LGhassen/basic_pathtracer/blob/master/img/1.jpg" ></p>

<p align="center"><img src="https://github.com/LGhassen/basic_pathtracer/blob/master/img/2.jpg" ></p>

<p align="center"><img src="https://github.com/LGhassen/basic_pathtracer/blob/master/img/3.jpg" ></p>

<p align="center"><img src="https://github.com/LGhassen/basic_pathtracer/blob/master/img/4.jpg" ></p>

<p align="center"><img src="https://github.com/LGhassen/basic_pathtracer/blob/master/img/5.jpg" ></p>

<p align="center"><img src="https://github.com/LGhassen/basic_pathtracer/blob/master/img/6.jpg" ></p>

## Notes
-Arbitrary box rotation is not implemented because the code used only handles axis-aligned bounding-boxes (can be added to the existing code by multiplying the rayDir with the box rotation matrix).
-Explicit light sampling was partially implemented, currently not implemented for box light sources. Also light sources look wrong in reflections.