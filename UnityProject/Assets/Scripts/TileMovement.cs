using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileMovement : MonoBehaviour
{
  static TilesSorting sTilesSorting = new TilesSorting();

  // Global setting to disable tile movement.
  public static bool TileMovementEnabled
  {
    get;
    set;
  } = true;

  #region Private variables
  // cache the sprite renderer.
  SpriteRenderer mSpriteRenderer;

  // a variable to store the offset
  // when we click on the tile. This variable
  // is needed to implement drag functionality
  // of the tile/sprite.
  Vector3 mOffset = new Vector3(0.0f, 0.0f, 0.0f);
  #endregion

  void Start()
  {
    mSpriteRenderer = GetComponent<SpriteRenderer>();
    sTilesSorting.Add(mSpriteRenderer);
  }

  void OnMouseDown()
  {
    if (EventSystem.current.IsPointerOverGameObject())
    {
      return;
    }

    if (!TileMovementEnabled || !enabled)
      return;

    // Hit piece. So disable the camera panning.
    CameraManipulator2D.IsCameraPanning = false;

    sTilesSorting.BringToTop(mSpriteRenderer);

    mOffset = transform.position - 
      Camera.main.ScreenToWorldPoint(
        new Vector3(
          Input.mousePosition.x, 
          Input.mousePosition.y, 
          0.0f));
  }

  void OnMouseDrag()
  {
    if (EventSystem.current.IsPointerOverGameObject())
    {
      return;
    }

    if (!TileMovementEnabled || !enabled)
      return;

    Vector3 curScreenPoint = 
      new Vector3(
        Input.mousePosition.x, 
        Input.mousePosition.y, 
        0.0f);
    Vector3 curPosition = 
      Camera.main.ScreenToWorldPoint(curScreenPoint) + 
      mOffset;

    transform.position = curPosition;
  }

  void OnMouseUp()
  {
    if (EventSystem.current.IsPointerOverGameObject())
    {
      return;
    }

    if (!TileMovementEnabled || !enabled)
      return;

    // Enable back the camera panning.
    CameraManipulator2D.IsCameraPanning = true;
  }
}
