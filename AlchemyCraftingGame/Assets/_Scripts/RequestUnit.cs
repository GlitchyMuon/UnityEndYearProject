using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RequestUnit : MonoBehaviour
{
    public TextMeshProUGUI requestText;

    // Start is called before the first frame update
    void Start()
    {
        requestText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetRequestData(RequestSO request)
    {
        GetComponentInChildren<RequestInstantiator>().associatedRequestSO = request;
        if (requestText == null)
        {
            requestText = GetComponentInChildren<TextMeshProUGUI>();
        }
        requestText.SetText($"Request from <b>{request.VillagerName}</b>\n{request.Description} : ");

    }
}
