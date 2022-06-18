using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    public LayerMask clickableLayer;//è cliccabile?

    public Texture2D pointer;//puoi cliccare
    public Texture2D pointerBlank;//non puoi cliccare
    public Texture2D target;//interagisci
    public Texture2D combat;
    public Texture2D doorway;

    public EventVector3 OnClickEnvironment;//event, per il mouse per forza

    //fun start = initialize alla variables when the game start
    //update = every frame, mouse per forza

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))//camera, è cliccabile?
        {
            bool door = false;
            bool item = false;

            //tags per il cursore che cambia
            if (hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }
            else if (hit.collider.gameObject.tag == "Item")
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                item = true;
            }
            else
            {
                Cursor.SetCursor(pointer, new Vector2(16, 16), CursorMode.Auto);
            }

            //tasto sinistro sul cliccabile
            if (Input.GetMouseButtonDown(0))
            {
                if (door)
                {
                    Transform doorway = hit.collider.gameObject.transform;
                    OnClickEnvironment.Invoke(doorway.position);

                    Debug.Log("DOOR");
                }
                else if (item)
                {
                    Transform itemPos = hit.collider.gameObject.transform;
                    OnClickEnvironment.Invoke(itemPos.position);

                    Debug.Log("ITEM");
                }
                else
                {
                    OnClickEnvironment.Invoke(hit.point);
                }
            }
        }
        else
        {
            Cursor.SetCursor(pointerBlank, Vector2.zero, CursorMode.Auto);
        }
    }

    //disponibile al di fuori, quindi nell inspector
    [System.Serializable]
    public class EventVector3 : UnityEvent<Vector3> { }//giochetto per far si che sia leggibile eventvector3
}
