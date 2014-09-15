speccix
============
A simple framework for Unity that simulates attribute clash of ZX Spectrum & help in various things (borders, camera, ecc.)
============
attribute clash usage
Add the script "startAttributeClash" & "attributeClash" to the camera. The sprites must have the script "sprite" & shader "sprite" to be affected by the attribute clashes The variable "single_color" defines how the sprite reacts to the attribute, if -1 no attribute will be changed, if != -1 then the sprite will influence the attribute with the specified color in this table: http://upload.wikimedia.org/wikipedia/commons/0/02/Zx-colors.png (color 1 is the black on the top left, 9 is the black in top right, so the dim red is number 3)
============
setup & border
The "setupSpeccy" script must be called on the first scene, you can set either if the game has or has not a border and the target framerate (vsync must be disabled). The script "setResolution" & "setupCamera" must be applied on the main camera on every scene, they set the resolution & resize the viewport so the game is centered in the border.
