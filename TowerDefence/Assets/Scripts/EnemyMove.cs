using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject[] movePoints;
    [SerializeField] private float speed;
    private int point;
    private void Start()
    {
        point = 0;
        movePoints = GameObject.FindGameObjectsWithTag("Points");
    }
    private void Update()
    { 
        transform.position = Vector2.MoveTowards(transform.position, movePoints[point].transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePoints[point].transform.position) < 0.1)
        {
            point++;
        }
    }
}
