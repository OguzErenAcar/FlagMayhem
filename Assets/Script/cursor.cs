using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    public Texture2D mouseCursor;

   
    CursorMode cursorMode = CursorMode.ForceSoftware;

    private void Start()
    {
        Cursor.SetCursor(mouseCursor, Vector2.zero, cursorMode);
    }
}
