using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private Rigidbody rb;
    private int yRotation;
    
    [Header("Move Attributes")]
    [SerializeField] private float speed;

    [Header("Body Attributes")]
    [SerializeField] private GameObject tailPrefab;
    [SerializeField] private GameObject bodyPrefab;
    [SerializeField] private int Gap;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject cloneParent;

    [Header("Respawning")]
    [SerializeField] private Transform sp;

    List<GameObject> BodyParts = new List<GameObject>();
    List<Vector3> PositionHistory = new List<Vector3>();

    private int lastBP;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        yRotation = 0;
    }
    private void Start()
    {
        GameManager.instance.OnRestartSnake += RestartActivated;
        cloneParent = GameObject.FindGameObjectWithTag("CloneParent");
    }

    private void FixedUpdate()
    {
        ForwardMovement();

        PositionHistory.Insert(0, transform.position);

        int index = 1;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionHistory[Mathf.Clamp(index * Gap, 0, PositionHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * speed;

            body.transform.LookAt(point);

            index++;
        }
    }

    #region Movement
    private void ForwardMovement()
    {
        //rb.transform.position += new Vector3(0, 0, speed);
        rb.velocity = transform.forward * speed;
        //rb.transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void RotateRight()
    {
        //rb.transform.localRotation = Quaternion.Euler(0, 90, 0);

        if(yRotation == 0)
        {
            rb.transform.localRotation = Quaternion.Euler(0, 90, 0);
            yRotation = 90;
        }
        else if (yRotation == 90)
        {
            rb.transform.localRotation = Quaternion.Euler(0, 180, 0);
            yRotation = 180;
        }

        else if (yRotation == 180)
        {
            rb.transform.localRotation = Quaternion.Euler(0, 270, 0);
            yRotation = 270;
        }

        else if (yRotation == 270)
        {
            rb.transform.localRotation = Quaternion.Euler(0, 360, 0);
            yRotation = 0;
        }
    }

    public void RotateLeft()
    {
        //rb.transform.localRotation = Quaternion.Euler(0, 90, 0);

        if (yRotation == 0)
        {
            rb.transform.localRotation = Quaternion.Euler(0, 270, 0);
            yRotation = 270;
        }
        else if (yRotation == 270)
        {
            rb.transform.localRotation = Quaternion.Euler(0, 180, 0);
            yRotation = 180;
        }

        else if (yRotation == 180)
        {
            rb.transform.localRotation = Quaternion.Euler(0, 90, 0);
            yRotation = 90;
        }

        else if (yRotation == 90)
        {
            rb.transform.localRotation = Quaternion.Euler(0, 0, 0);
            yRotation = 0;
        }
    }

    #endregion Movement

    
    public void GrowSnake()
    {
        if (BodyParts.Count == 0)
        {
            GameObject body = Instantiate(bodyPrefab, spawnPoint.position, rb.rotation, cloneParent.transform);
            BodyParts.Add(body);
            lastBP++;
            Debug.Log("Body Part added. BD Count = " + BodyParts.Count);
        }
        else if (BodyParts.Count > 0)
        {
            Debug.Log("Trying to add BP");

            GameObject body = Instantiate(bodyPrefab, BodyParts[lastBP-1].transform.position, rb.rotation, cloneParent.transform);
            BodyParts.Add(body);
            lastBP++;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyPlayer"))
        {
            Time.timeScale = 0f;
            GameManager.instance.GameOver();
        }

        if(other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            GameManager.instance.score++;
            GrowSnake();
        }
    }

    private void RestartActivated()
    {
        BodyParts.Clear();
        lastBP = 0;
        yRotation = 0;
        //Vector3 playerSpawnPosition = new Vector3(0f, 0.01f, 0f);
        Vector3 playerSpawnPosition = sp.position;
        rb.transform.position = playerSpawnPosition;
        rb.transform.rotation = Quaternion.identity;
        Time.timeScale = 1f;
    }
}
