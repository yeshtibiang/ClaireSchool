using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChildScript : MonoBehaviour
{

    private GameObject particle;
    private NavMeshAgent agentChild;
    private Animator animatorChild;
    
    // target de l'enfant. 
    [SerializeField] private Transform target;
    private AudioSource audioSourcChild;
    // transform du player
    [SerializeField] private AudioClip sndExplosion;
    private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
