using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject waypoint_one;
    public GameObject waypoint_two;
    public GameObject waypoint_three;
    public GameObject coin_one;
    public GameObject coin_two;
    public GameObject coin_three;

    private int flag;
    private Vector3 distVec;
    private NavMeshAgent enemy;
    private bool inmune;

    // Start is called before the first frame update
    void Start()
    {
        flag = 1;
        enemy = gameObject.GetComponent<NavMeshAgent>();
        inmune = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == 1 && waypoint_one && !enemy.hasPath) 
        {
            flag = 2;
            distVec = waypoint_one.transform.position;
            enemy.SetDestination(distVec);
        }

        else if (flag == 2 && waypoint_two && !enemy.hasPath)
        {
            flag = 3;
            distVec = waypoint_two.transform.position;
            enemy.SetDestination(distVec);
        }

        else if (flag == 3 && waypoint_three && !enemy.hasPath)
        {
            flag = 1;
            distVec = waypoint_three.transform.position;
            enemy.SetDestination(distVec);
        }

        if (!coin_one && !coin_two && !coin_three)
            inmune = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !inmune)
            Destroy(collision.gameObject);
    }
}
