using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Map : ScriptableObject
{
    public string mapName;
    public string mapDescription;
    public Sprite mapImage;
    public GameObject mapPrefab;
}
