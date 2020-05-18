using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    private NavMeshAgent walker;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        walker = gameObject.GetComponent<NavMeshAgent>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && walker) 
        {
            Ray myRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(myRay, out hit)) 
            {
                walker.SetDestination(hit.point);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            score += 1;
        }
        else if (collision.gameObject.CompareTag("Enemy")) 
        {
            Destroy(collision.gameObject);
        }
    }
}
