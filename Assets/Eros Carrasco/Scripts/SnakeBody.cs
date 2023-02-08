using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.OnRestartSnake += AutoDestruction;
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
