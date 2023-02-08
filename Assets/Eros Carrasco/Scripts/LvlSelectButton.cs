using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlSelectButton : MonoBehaviour
{

   
    public void Lvl1()
    {
        GameManager.instance.Lvl1Selected();
    }
    public void Lvl2()
    {
        GameManager.instance.Lvl2Selected();
    }
    public void Lvl3()
    {
        GameManager.instance.Lvl3Selected();
    }
}
