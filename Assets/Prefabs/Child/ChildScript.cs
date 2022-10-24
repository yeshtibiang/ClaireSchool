using System;
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
        particle = transform.Find("Particle").gameObject;
        agentChild = GetComponentInChildren<NavMeshAgent>();
        animatorChild = GetComponentInChildren<Animator>();
        audioSourcChild = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // on détruit la cage
            audioSourcChild.PlayOneShot(sndExplosion);
            particle.SetActive(true);
            Destroy(transform.Find("Cage").gameObject);
            // desactiver le collider sur le child
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
