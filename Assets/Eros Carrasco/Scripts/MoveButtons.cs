using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtons : MonoBehaviour
{
    [SerializeField] private SnakeController sc;
    //[SerializeField] private SnakeController otherSc;

    //[SerializeField] private GameObject[] snake;

    private void Start()
    {
        //snake = GameObject.FindGameObjectsWithTag("Player");
        //sc = GetComponent<SnakeController>();
        sc = GameObject.FindGameObjectWithTag("Player").GetComponent<SnakeController>();
    }


    public void RotateRigth()
    {
        sc.RotateRight();
    }

    public void RotateLeft()
    {
        sc.RotateLeft();
    }

    public void AddBody()
    {
        sc.GrowSnake();
    }
}
