using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    private TMP_Text texto;
    private void Start()
    {
        texto = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        texto.text = GameManager.instance.score.ToString();
    }
}
