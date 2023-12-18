using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickConfirmPanel : MonoBehaviour
{
    public GameObject onClickPanelPopup;
    // Start is called before the first frame update
    void Start()
    {
        
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
