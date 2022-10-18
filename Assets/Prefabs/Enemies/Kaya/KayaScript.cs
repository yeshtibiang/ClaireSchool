using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KayaScript : MonoBehaviour
{
    private NavMeshAgent kayaAgent;
    private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        kayaAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        kayaAgent.SetDestination(target.position);
    }
}
