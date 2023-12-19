using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestInstantiator : MonoBehaviour
{
    public GameObject requestPrefab;

    public GridLayoutGroup gridLayoutGroup;

    [HideInInspector] public RequestSO associatedRequestSO;

    public List<RequestSO> requests;

    // Start is called before the first frame update
    void Start()
    {
        if (gridLayoutGroup == null)
        {
            gridLayoutGroup = FindObjectOfType<GridLayoutGroup>();
            if (gridLayoutGroup == null)
            {
                Debug.LogError("GridLayoutGroup not found. Make sure it is assigned or present in the scene.");
                return;
            }
        }
        InstantiateRequests();
    }

    void InstantiateRequests()
    {
        foreach (RequestSO request in requests)
        {
            //Instantiate the requests as new GameObjects
            GameObject newRequest = Instantiate(requestPrefab, gridLayoutGroup.transform);

            //Access the ScriptableObject data to the prefab script
            RequestUnit requestUnit = newRequest.GetComponent<RequestUnit>();

            if (requestUnit != null)
            {
                //Assign the ScriptableObject data to the prefab script
                requestUnit.SetRequestData(request);
            }
            else
            {
                Debug.LogError("RequestUnit script not found on the instantiated prefab.");
            }
        }
        // Log the number of instantiated recipes
        Debug.Log($"Number of instantiated requests: {gridLayoutGroup.transform.childCount}");
    }
}
