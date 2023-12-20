using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class OnClickConfirmPanel : MonoBehaviour
{
    public GameObject onClickPanelPopup;    //UnityEngine.UIElements.Image ?
    // Start is called before the first frame update
    void Start()
    {
        onClickPanelPopup = GameObject.Find("RequestBoardInstantiator/RequestBoard/Scroll View/ConfirmPanel");
        //onClickPanelPopup = GetComponentInParent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClick()
    {
        onClickPanelPopup.SetActive(true);
    }
}
