using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private List<Map> maps = new List<Map>();
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private MapButtonManager mapButtonManager;
    void Start()
    {
        GameManager.instance.OnLevelSelect += CreateButtons;
    }

    private void CreateButtons()
    {
        foreach (var map in maps)
        {
            MapButtonManager mapButton;
            mapButton = Instantiate(mapButtonManager, buttonContainer.transform);
            mapButton.MapName = map.mapName;
            mapButton.MapDescription = map.mapDescription;
            mapButton.MapImage = map.mapImage;
            mapButton.MapPrefab = map.mapPrefab;

            mapButton.name = map.mapName;
        }

        GameManager.instance.OnLevelSelect -= CreateButtons;
    }

    
}
