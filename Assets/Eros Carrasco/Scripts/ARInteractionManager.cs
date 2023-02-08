using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class ARInteractionManager : MonoBehaviour
{
    [SerializeField] private Camera aRCamera;
    private ARRaycastManager aRRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject aRPointer;
    private GameObject mapPrefab;

    private bool isInitialPosition;

    public GameObject MapPrefab
    {
        set
        {
            mapPrefab = value;
            mapPrefab.transform.position = aRPointer.transform.position;
            mapPrefab.transform.parent = aRPointer.transform;
            isInitialPosition = true;
        }
    }
    void Start()
    {
        aRPointer = transform.GetChild(0).gameObject;
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        GameManager.instance.OnLevelCreated += SetMapPosition;
    }

    public void SetMapPosition()
    {
        if(mapPrefab != null)
        {
            mapPrefab.transform.parent = null;
            aRPointer.SetActive(false);
            mapPrefab = null;
            GameManager.instance.StartSnake();
        }
        if(mapPrefab == null)
        {
            Debug.Log("Map is null");
        }
    }

    public void DeleteMap()
    {
        Destroy(mapPrefab);
        aRPointer.SetActive(false);
        GameManager.instance.LevelSelect();
    }

    void Update()
    {
        if (isInitialPosition)
        {
            Vector2 middlePointScreen = new Vector2(Screen.width / 2, Screen.height / 2);
            aRRaycastManager.Raycast(middlePointScreen, hits, TrackableType.Planes);

            if( hits.Count>0)
            {
                transform.position = hits[0].pose.position;
                transform.rotation = hits[0].pose.rotation;
                aRPointer.SetActive(true);
                isInitialPosition = false;
            }
        }
    }
}
