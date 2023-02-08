using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestruction : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.OnTutorial += AutoDestruction;
    }

    private void AutoDestruction()
    {
        try
        {
            Destroy(this.gameObject);
        }
        catch
        {
            Debug.Log("Object already destroyed");
        }
    }
}
