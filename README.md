# Runtime Depth Sorting of Sprites in a Layer

In this tutorial, we will learn to implement runtime depth sorting of sprites in a layer.

Typically, you can associate a RenderOrder to a sprite in Unity editor. However, there may be situations where you would want to reorder the sprite render order, and set the correct z value at runtime based on the sprite that you select or pick in-game.

For example, in a Jigsaw game, all the tiles can be in the same layer with the same depth. However, based on which tile you pick, you want to bring it up in the render order to draw it on top of all other tiles and set the correct z value so that raycast can also pick it up even if it overlaps with other tiles.

By the end of this tutorial, we want to achieve the following:

* Click a sprite and bring it to the top,
* Click and drag to move a sprite,
* Click and pan camera when the click on not on any sprite, and
* Slider to zoom-in and zoom-out of camera (optional buttons to do the same)



