using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;

    private Vector2 cursorHotspot;
    // Start is called before the first frame update
    void Start()
    {
        //If cursor target points from midle of texture, not top left
       //cursorHotspot = new Vector2(cursorTexture.width /2, cursorTexture.height/2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto); //last parameter determines wether the cursor is hardware or software rendered. Alternative : CursorMode.ForceSoftware 
        //CursorMode.Hardware
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
