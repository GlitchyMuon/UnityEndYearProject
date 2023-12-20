using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPanelButtonEventListener : MonoBehaviour
{
    public Button acceptRequestButton, refuseRequestButton;

    public int activeRequest;
    // Start is called before the first frame update
    void Start()
    {
        acceptRequestButton.onClick.AddListener(ActiveRequestMemory);
        refuseRequestButton.onClick.AddListener(DestroyScriptInstance);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DestroyScriptInstance()
    {
        // Removes this script instance from the game object
        Destroy(this);
        Debug.Log("You have refused this request! Instance of it is destroyed.");
    }

    void ActiveRequestMemory()
    {
        activeRequest = GetInstanceID();
    }
}
