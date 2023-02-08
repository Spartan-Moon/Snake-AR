using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MapButtonManager : MonoBehaviour
{
    private string mapName;
    private string mapDescription;
    private Sprite mapImage;
    private GameObject mapPrefab;

    private ARInteractionManager interactionManager;
    public string MapName { set { mapName = value; } }
    public string MapDescription { set { mapDescription = value; } }
    public Sprite MapImage { set { mapImage = value; } }
    public GameObject MapPrefab { set { mapPrefab = value; } }

    private void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = mapName;
        transform.GetChild(1).GetComponent<TMP_Text>().text = mapDescription;
        transform.GetChild(2).GetComponent<RawImage>().texture = mapImage.texture;

        
        //var button = GetComponent<Button>(); Debug.Log("Got Component");
        //button.onClick.AddListener(GameManager.instance.ARPosition);
        //button.onClick.AddListener(CreateMap); Debug.Log("Calling Create Map");

        interactionManager = FindObjectOfType<ARInteractionManager>(); 
    }

    public void CreateMap()
    {
        Debug.Log("Creat Map Called");
        interactionManager.MapPrefab =  Instantiate(mapPrefab);
        //Instantiate(mapPrefab);
        GameManager.instance.LevelCreated();
        GameManager.instance.ARPosition();
    }
}
